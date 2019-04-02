using AdvocacyPro.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvocacyPro.Models.Result
{
    public class CreateUserResult
    {
        public bool Success { get; set; }
        public MemberData CreatedUser { get; set; }
        public CreateUserFailure FailureReason { get; set; }
        public string ErrorDescription
        {
            get
            {
                switch (this.FailureReason)
                {
                    case CreateUserFailure.DuplicateUser:
                        return "A user with this email address already exists in the system.";
                    default:
                        return "An error occurred while creating this account.  Please check your input and try again.";
                }
            }
        }
    }
    public enum CreateUserFailure
    {
        DuplicateUser = 0
    }
}
