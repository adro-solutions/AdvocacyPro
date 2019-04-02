using System.ComponentModel.DataAnnotations;

namespace AdvocacyPro.Models.DTO
{
    public class MemberData
    {
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string FirstName { get; set; }
        [Required, MaxLength(20)]
        public string LastName { get; set; }
        [EmailAddress, Required, MaxLength(50)]
        public string Email { get; set; }
        public int OrganizationId { get; set; }
        [Required, MinLength(8), RegularExpression(@"^.*(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!#$%&?]).*$")]
        public string Password { get; set; }
    }
}
