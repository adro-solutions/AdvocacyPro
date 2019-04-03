using AdvocacyPro.Data;
using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.DTO;
using AdvocacyPro.Models.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdvocacyPro.Services
{

    public class AuthLogic
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration config;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly DataContext db;

        public AuthLogic(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration config,
            IHttpContextAccessor contextAccessor,
            DataContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.config = config;
            this.contextAccessor = contextAccessor;
            this.db = db;
        }

        public async Task ForgotPassword(string emailAddress)
        {
            var user = await _userManager.FindByNameAsync(emailAddress);
            if (user == null) // || !(await _userManager.IsEmailConfirmedAsync(user))
                return;

            // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
            // Send an email with this link
            var code = System.Net.WebUtility.UrlEncode(await _userManager.GeneratePasswordResetTokenAsync(user));
            var callbackUrl = $"{contextAccessor.HttpContext.Request.Scheme}://{contextAccessor.HttpContext.Request.Host}/resetpassword?code={code}";

            SendGridClient client = new SendGridClient(config["SendGrid:ApiKey"]);
            
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(config["SendGrid:FromAddress"], config["SendGrid:FromName"]),
                Subject = "Reset password request",
                HtmlContent = $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>"
            };
            msg.AddTo(new EmailAddress(user.Email, user.FirstName + " " + user.LastName));
            var response = await client.SendEmailAsync(msg);
        }

        public async Task<ChangePasswordResult> ResetPassword(ResetPassword model)
        {
            ChangePasswordResult result = new ChangePasswordResult();
            result.Success = false;

            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                result.FailureReason = ChangePasswordFailure.UserNotFound;
                return result;
            }
            var pwdResult = await _userManager.ResetPasswordAsync(user, model.Code, model.NewPassword);
            if (!pwdResult.Succeeded)
            {
                if (pwdResult.Errors.Any(e => e.Code == "InvalidToken"))
                    result.FailureReason = ChangePasswordFailure.IncorrectPassword;
                else
                    result.FailureReason = ChangePasswordFailure.PasswordRequirements;
                return result;
            }

            result.Success = true;
            return result;
        }

        public async Task<ChangePasswordResult> ChangePassword(string email, ChangePassword model)
        {
            ChangePasswordResult result = new ChangePasswordResult();
            result.Success = false;

            var user = await _userManager.FindByNameAsync(email);
            if (user == null)
            {
                result.FailureReason = ChangePasswordFailure.UserNotFound;
                return result;
            }
            var pwdResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!pwdResult.Succeeded)
            {
                if (pwdResult.Errors.Any(e => e.Code == "PasswordMismatch"))
                    result.FailureReason = ChangePasswordFailure.IncorrectPassword;
                else
                    result.FailureReason = ChangePasswordFailure.PasswordRequirements;

                return result;
            }

            result.Success = true;
            return result;
        }

        public async Task<Models.Result.SignInResult> SignIn (string username, string password, string grantType)
        {
            Models.Result.SignInResult result = new Models.Result.SignInResult();
            result.Success = false;            

            if (grantType == "password")
            { 
                var signInResult = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);
                if (!signInResult.Succeeded)
                {
                    result.FailureReason = SignInFailure.UsernamePasswordInvalid;
                    return result;
                }
                var user = _userManager.Users.First(i => i.UserName == username);
                if (!user.LockoutEnabled)
                {
                    result.FailureReason = SignInFailure.UsernamePasswordInvalid;
                    return result;
                }

                result.AuthToken = GetLoginToken(user);
                result.Success = true;
            }
            else
            {
                result.FailureReason = SignInFailure.InvalidGrantType;
            }


            return result;
        }

        public string GetLoginToken(User user)
        {
            var options = GetOptions();
            var now = DateTime.UtcNow;

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUniversalTime().ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
            };

            var userClaims = db.UserClaims.Where(i => i.UserId == user.Id);
            foreach (var userClaim in userClaims)
            {
                claims.Add(new Claim(userClaim.ClaimType, userClaim.ClaimValue));
            }
            
            var org = db.Organization.First(o => o.Id == user.OrganizationId);

            claims.Add(new Claim(ClaimTypes.UserData,
                JsonConvert.SerializeObject(new UserData(user, org))));

            var jwt = new JwtSecurityToken(
                issuer: options.Issuer,
                audience: options.Audience,
                claims: claims.ToArray(),
                notBefore: now,
                expires: now.Add(options.Expiration),
                signingCredentials: options.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            
            return encodedJwt;
        }

        private TokenProviderOptions GetOptions()
        {
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config["TokenAuthentication:SecretKey"]));

            return new TokenProviderOptions
            {
                Path = config["TokenAuthentication:TokenPath"],
                Audience = config["TokenAuthentication:Audience"],
                Issuer = config["TokenAuthentication:Issuer"],
                Expiration = TimeSpan.FromMinutes(Convert.ToInt32(config["TokenAuthentication:ExpirationMinutes"])),
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            };
        }
    }
}
