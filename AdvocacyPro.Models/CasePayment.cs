using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Base;
using AdvocacyPro.Models.Values;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvocacyPro.Models
{
    public class CasePayment : TrackedBase, ICaseChild
    {
        public int Id { get; set; }
        public int CaseId { get; set; }

        public int? PaymentCategoryId { get; set; }

        public decimal? AmountSubmitted { get; set; }

        public decimal? AmountApproved { get; set; }

        public int? ApprovedById { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public int? SubmittedById { get; set; }

        public DateTime? SubmittedDate { get; set; }

        public string ClaimId { get; set; }

        public int? PayorId { get; set; }

        public string Comments { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CasePayment>().Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<CasePayment>().HasOne<Case>().WithMany(c => c.Payments).HasForeignKey(c => c.CaseId);
            modelBuilder.Entity<CasePayment>().HasOne<User>().WithMany().HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<CasePayment>().HasOne<User>().WithMany().HasForeignKey(c => c.UpdatedById);
            modelBuilder.Entity<CasePayment>().HasOne<User>().WithMany().HasForeignKey(c => c.ApprovedById);
            modelBuilder.Entity<CasePayment>().HasOne<User>().WithMany().HasForeignKey(c => c.SubmittedById);
            modelBuilder.Entity<CasePayment>().HasOne<Payor>().WithMany().HasForeignKey(c => c.PayorId);
            modelBuilder.Entity<CasePayment>().HasOne<PaymentCategory>().WithMany().HasForeignKey(c => c.PaymentCategoryId);
        }
    }
}
