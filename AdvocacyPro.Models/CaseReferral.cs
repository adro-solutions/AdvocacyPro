using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Base;
using AdvocacyPro.Models.Values;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models
{
    public class CaseReferral : TrackedBase, ICaseChild
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        [Required, MaxLength(50)]
        public string Source { get; set; }

        public int TypeId { get; set; }

        [Required, MaxLength(100)]
        public string Contact { get; set; }

        public DateTime? FollowupDate { get; set; }
        public DateTime? ContactDate { get; set; }

        public string Notes { get; set; }
        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseReferral>().Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<CaseReferral>().HasOne<ReferralType>().WithMany().HasForeignKey(c => c.TypeId);
            modelBuilder.Entity<CaseReferral>().HasOne<Case>().WithMany(c => c.Referrals).HasForeignKey(c => c.CaseId);
            modelBuilder.Entity<CaseReferral>().HasOne<User>().WithMany().HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<CaseReferral>().HasOne<User>().WithMany().HasForeignKey(c => c.UpdatedById);

        }
    }
}
