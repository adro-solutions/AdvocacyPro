using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Base;
using AdvocacyPro.Models.Values;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdvocacyPro.Models
{
    public class CaseCVCApplication : TrackedBase, ICaseChild
    {
        public int Id { get; set; }
        public int CaseId { get; set; }

        public string CVCNumber { get; set; }

        public DateTime? CVCDate { get; set; }

        [Required]
        [Display(Name = "Application Status")]
        public int ApplicationStatusId { get; set; }

        [Required]
        [Display(Name = "Offense")]
        public int OffenseTypeId { get; set; }

        public int? ReferralTypeId { get; set; }

        [MaxLength(50)]
        public string ReferralOther { get; set; }

        [MaxLength(100)]
        public string Defendant { get; set; }

        public string Notes { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseCVCApplication>().Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<CaseCVCApplication>().HasOne<Case>().WithMany(c => c.CVCApplications).HasForeignKey(c => c.CaseId);
            modelBuilder.Entity<CaseCVCApplication>().HasOne<User>().WithMany().HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<CaseCVCApplication>().HasOne<User>().WithMany().HasForeignKey(c => c.UpdatedById);
            modelBuilder.Entity<CaseCVCApplication>().HasOne<ApplicationStatus>().WithMany().HasForeignKey(c => c.ApplicationStatusId);
            modelBuilder.Entity<CaseCVCApplication>().HasOne<OffenseType>().WithMany().HasForeignKey(c => c.OffenseTypeId);
            modelBuilder.Entity<CaseCVCApplication>().HasOne<ReferralType>().WithMany().HasForeignKey(c => c.ReferralTypeId);
        }
    }
}
