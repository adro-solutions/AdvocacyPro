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
    public class CaseIncident : TrackedBase, ICaseChild
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        [Required]
        [Display(Name = "Offense")]
        public int OffenseId { get; set; }

        public DateTime ReportDate { get; set; }
        [Required, Display(Name = "Occurrence Date")]
        public DateTime OccurrenceDate { get; set; }
        [Required, MaxLength(50)]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Location type")]
        public int LocationTypeId { get; set; }

        [Required]
        public int StaffUserId { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int StatusId { get; set; }

        [MaxLength(50)]
        public string Disposition { get; set; }
        public string Notes { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseIncident>().Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<CaseIncident>().HasOne<User>().WithMany().HasForeignKey(c => c.StaffUserId);
            modelBuilder.Entity<CaseIncident>().HasOne<Status>().WithMany().HasForeignKey(c => c.StatusId);
            modelBuilder.Entity<CaseIncident>().HasOne<LocationType>().WithMany().HasForeignKey(c => c.LocationTypeId);
            modelBuilder.Entity<CaseIncident>().HasOne<Offense>().WithMany().HasForeignKey(c => c.OffenseId);
            modelBuilder.Entity<CaseIncident>().HasOne<Case>().WithMany(c => c.Incidents).HasForeignKey(c => c.CaseId);
            modelBuilder.Entity<CaseIncident>().HasOne<User>().WithMany().HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<CaseIncident>().HasOne<User>().WithMany().HasForeignKey(c => c.UpdatedById);


        }
    }
}
