using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Values;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvocacyPro.Models.Auth
{
    public class User : IdentityUser<int>
    {
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }
        
        [MaxLength(30)]
        public string City { get; set; }

        [MaxLength(30)]
        public string State { get; set; }

        [MaxLength(10)]
        public string ZipCode { get; set; }

        [MaxLength(50)]
        public string Address1 { get; set; }

        [MaxLength(50)]
        public string Address2 { get; set; }

        [MaxLength(50)]
        public string Address3 { get; set; }

        [MaxLength(20)]
        public string DayPhone { get; set; }

        [MaxLength(20)]
        public string EveningPhone { get; set; }

        [MaxLength(20)]
        public string Fax { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? LastLoginDate { get; set; }
        [MaxLength(5)]
        public string Initials { get; set; }

        public int OrganizationId { get; set; }
        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne<Organization>().WithMany().HasForeignKey( o => o.OrganizationId);
        }
    }
}
