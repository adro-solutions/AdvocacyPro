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
    public class CaseCourtDate : TrackedBase, ICaseChild
    {
        public int Id { get; set; }
        public int CaseId { get; set; }

        [MaxLength(100)]
        public string DocketNumber { get; set; }

        [Required]
        public int DocketTypeId { get; set; }

        [MaxLength(250)]
        public string Court { get; set; }

        [MaxLength(250)]
        public string Police { get; set; } // TODO: Should this link to case police?????

        public DateTime? ArrestDate { get; set; }

        public decimal BondAmount { get; set; }

        [Required]
        public int BondTypeId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Purpose { get; set; }

        public string Reason { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseCourtDate>().Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<CaseCourtDate>().HasOne<Case>().WithMany(c => c.CourtDates).HasForeignKey(c => c.CaseId);
            modelBuilder.Entity<CaseCourtDate>().HasOne<User>().WithMany().HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<CaseCourtDate>().HasOne<User>().WithMany().HasForeignKey(c => c.UpdatedById);
            modelBuilder.Entity<CaseCourtDate>().HasOne<DocketType>().WithMany().HasForeignKey(c => c.DocketTypeId);
            modelBuilder.Entity<CaseCourtDate>().HasOne<BondType>().WithMany().HasForeignKey(c => c.BondTypeId);
        }
    }
}
