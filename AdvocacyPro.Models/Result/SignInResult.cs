using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Result
{
    public class SignInResult
    {
        public bool Success { get; set; }
        public SignInFailure FailureReason { get; set; }
        public string AuthToken { get; set; }
        public string ErrorDescription
        {
            get
            {
                switch(this.FailureReason)
                {
                    case SignInFailure.UserCannotLogin:
                        return "Your account is unable to sign in.  Please contact your administrator.";
                    case SignInFailure.InvalidGrantType:
                        return "Login attempt failed.  Invalid request type.";
                    default:
                        return "The username or password you have entered are invalid.";
                }
            }
        }
    }

    public enum SignInFailure
    {
        UsernamePasswordInvalid = 0,
        UserCannotLogin = 1,
        InvalidGrantType = 2
    }
}
