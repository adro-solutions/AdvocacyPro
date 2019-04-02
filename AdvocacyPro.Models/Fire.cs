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

namespace AdvocacyPro.Models
{
    public class Fire : TrackedBase
    {
        public int Id { get; set; }

        public DateTime? ReportDate { get; set; }
        public DateTime? OccurrenceDate { get; set; }

        [Required, MaxLength(50)]
        public string Location { get; set; }

        public int? LocationTypeId { get; set; }

        public int StatusId { get; set; }
        [Required]
        public int CauseId { get; set; }

        [MaxLength(100)]
        public string Disposition { get; set; }

        public string Notes { get; set; }

        public int OrganizationId { get; set; }

        public int? StaffUserId { get; set; }

        public bool Archived { get; set; }
        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fire>().Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<Fire>().HasOne<FireCause>().WithMany().HasForeignKey(c => c.CauseId);
            modelBuilder.Entity<Fire>().HasOne<LocationType>().WithMany().HasForeignKey(c => c.LocationTypeId);
            modelBuilder.Entity<Fire>().HasOne<Status>().WithMany().HasForeignKey(c => c.StatusId);
            modelBuilder.Entity<Fire>().HasOne<User>().WithMany().HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<Fire>().HasOne<User>().WithMany().HasForeignKey(c => c.UpdatedById);
            modelBuilder.Entity<Fire>().HasOne<Organization>().WithMany().HasForeignKey(c => c.OrganizationId);
            modelBuilder.Entity<Fire>().HasOne<User>().WithMany().HasForeignKey(c => c.StaffUserId);

        }
    }
}
