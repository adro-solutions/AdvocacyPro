using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdvocacyPro.Models.DTO
{
    public class ChangePassword
    {
        [Required, MinLength(8), RegularExpression(@"^.*(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!#$%&?]).*$")]
        public string CurrentPassword { get; set; }
        [Required, MinLength(8), RegularExpression(@"^.*(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!#$%&?]).*$")]
        public string NewPassword { get; set; }
        [Required, MinLength(8), RegularExpression(@"^.*(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!#$%&?]).*$")]
        public string NewPassword2 { get; set; }
    }
}
