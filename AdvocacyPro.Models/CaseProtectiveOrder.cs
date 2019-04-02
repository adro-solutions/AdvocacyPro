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
    public class CaseProtectiveOrder : TrackedBase, ICaseChild
    {
        public int Id { get; set; }
        public int CaseId { get; set; }

        [Required]
        [Display(Name = "Order Type")]
        public int  OrderTypeId { get; set; }

        [Required]
        [Display(Name = "Order Status")]
        public int OrderStatusId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Notes { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseProtectiveOrder>().Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<CaseProtectiveOrder>().HasOne<Case>().WithMany(c => c.ProtectiveOrders).HasForeignKey(c => c.CaseId);
            modelBuilder.Entity<CaseProtectiveOrder>().HasOne<User>().WithMany().HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<CaseProtectiveOrder>().HasOne<User>().WithMany().HasForeignKey(c => c.UpdatedById);
            modelBuilder.Entity<CaseProtectiveOrder>().HasOne<OrderStatus>().WithMany().HasForeignKey(c => c.OrderStatusId);
            modelBuilder.Entity<CaseProtectiveOrder>().HasOne<OrderType>().WithMany().HasForeignKey(c => c.OrderTypeId);
        }
    }
}
