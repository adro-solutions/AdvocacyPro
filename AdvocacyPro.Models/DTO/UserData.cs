using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Values;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace AdvocacyPro.Models.DTO
{
    public class UserData
    {
        public UserData() { }
        public UserData (User user, Organization organization)
        {
            Id = user.Id;
            OrganizationId = user.OrganizationId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Product = organization.Product;
        }
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Product Product { get; set; }
    }
}
