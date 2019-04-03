using AdvocacyPro.Services;
using AdvocacyPro.Models.DTO;
using AdvocacyPro.Models.Result;
using AdvocacyPro.Web.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvocacyPro.Web.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : AuthBaseController
    {
        private readonly AuthLogic logic;

        public AuthController(AuthLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost("[action]"), Produces("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> Token()
        {
            var grantType = HttpContext.Request.Form["grant_type"].ToString();
            var username = HttpContext.Request.Form["username"].ToString();
            var password = HttpContext.Request.Form["password"];

            Models.Result.SignInResult result = await logic.SignIn(username, password, grantType);

            if (result.Success)
                return Ok( new { token_type = "Bearer", access_token = result.AuthToken });
            
            Response.Headers.Add("X-ExceptionMessage", result.ErrorDescription);
            return BadRequest();
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPassword model)
        {
            await logic.ForgotPassword(model.EmailAddress);

            return Ok();
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPassword model)
        {
            ChangePasswordResult result = await logic.ResetPassword(model);

            if (result.Success)
                return Ok();

            Response.Headers.Add("X-ExceptionMessage", result.ErrorDescription);
            return BadRequest();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword model)
        {
            ChangePasswordResult result = await logic.ChangePassword(this.UserData.Email, model);

            if (result.Success)
                return Ok();

            Response.Headers.Add("X-ExceptionMessage", result.ErrorDescription);
            return BadRequest();
        }
    }
}
