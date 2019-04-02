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
    public class CaseVictimization : TrackedBase, ICaseChild
    {
        public int Id { get; set; }
        public int CaseId { get; set; }

        [Required]
        [Display(Name ="Victimization Type")]
        public int VictimTypeId { get; set; }

        [MaxLength(100)]
        public string ReportingAgency { get; set; }

        [MaxLength(100)]
        public string ReportNumber { get; set; }

        public DateTime? StartDate { get; set; }

        public string ReportDetails { get; set; }

        public string Comments { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseVictimization>().Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<CaseVictimization>().HasOne<Case>().WithMany(c => c.Victimizations).HasForeignKey(c => c.CaseId);
            modelBuilder.Entity<CaseVictimization>().HasOne<User>().WithMany().HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<CaseVictimization>().HasOne<User>().WithMany().HasForeignKey(c => c.UpdatedById);
            modelBuilder.Entity<CaseVictimization>().HasOne<VictimType>().WithMany().HasForeignKey(c => c.VictimTypeId);
        }
    }
}
