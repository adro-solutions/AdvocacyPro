using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Base;
using AdvocacyPro.Models.Values;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Values
{
    public class Organization : ValueBase
    {
        [EmailAddress, MaxLength(40)]
        public string Email { get; set; }

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

        [MaxLength(50)]
        public string PrimaryContact { get; set; }

        public string Description { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        [Phone, MaxLength(20)]
        public string Phone { get; set; }

        [Phone, MaxLength(20)]
        public string Fax { get; set; }

        [MaxLength(100)]
        public string Url { get; set; }

        [Required]
        public int TypeId { get; set; }

        public byte[] Logo { get; set; }

        [EnumDataType(typeof(Product))]
        public Product Product { get; set; }

        public List<OrganizationFeature> Features { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>().Property(o => o.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<Organization>().HasOne<OrganizationType>().WithMany().HasForeignKey("TypeId");

        }
    }
}
