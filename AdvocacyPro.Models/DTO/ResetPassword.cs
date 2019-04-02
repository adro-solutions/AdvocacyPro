using System.ComponentModel.DataAnnotations;

namespace AdvocacyPro.Models.DTO
{
    public class ResetPassword
    {
        [Required]
        public string Code { get; set; }
        [EmailAddress, Required, MaxLength(50)]
        public string Email { get; set; }
        [Required, MinLength(8), RegularExpression(@"^.*(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!#$%&?]).*$")]
        public string NewPassword { get; set; }
        [Required, MinLength(8), RegularExpression(@"^.*(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!#$%&?]).*$")]
        public string NewPassword2 { get; set; }
    }
}
