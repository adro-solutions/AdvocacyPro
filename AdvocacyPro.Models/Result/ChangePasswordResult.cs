using System;
using System.Collections.Generic;
using System.Text;

namespace AdvocacyPro.Models.Result
{
    public class ChangePasswordResult
    {
        public bool Success { get; set; }
        public ChangePasswordFailure FailureReason { get; set; }
        public string ErrorDescription
        {
            get
            {
                switch (this.FailureReason)
                {
                    case ChangePasswordFailure.PasswordRequirements:
                        return "Your password does not meet the minimum password requirements.";
                    case ChangePasswordFailure.IncorrectPassword:
                        return "The current password you have entered is incorrect.";
                    default:
                        return "The request to change your password is invalid.  Please check your input and try again.";
                }
            }
        }
    }
    public enum ChangePasswordFailure
    {
        PasswordRequirements = 0,
        UserNotFound = 1,
        IncorrectPassword = 2,
        InvalidToken = 3
    }
}
