using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdvocacyPro.Models.DTO
{
    public class ForgotPassword
    {
        [EmailAddress, Required]
        public string EmailAddress { get; set; }
    }
}
