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
    public class CaseService : TrackedBase, ICaseChild
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Program")]
        public int ProgramId { get; set; }

        public int? PopulationId { get; set; }
        
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Notes { get; set; }
        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseService>().Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<CaseService>().HasOne<ServiceCategory>().WithMany().HasForeignKey(c => c.CategoryId);
            modelBuilder.Entity<CaseService>().HasOne<ServiceProgram>().WithMany().HasForeignKey(c => c.ProgramId);
            modelBuilder.Entity<CaseService>().HasOne<ServicePopulation>().WithMany().HasForeignKey(c => c.PopulationId);
            modelBuilder.Entity<CaseService>().HasOne<Case>().WithMany(c => c.Services).HasForeignKey(c => c.CaseId);
            modelBuilder.Entity<CaseService>().HasOne<User>().WithMany().HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<CaseService>().HasOne<User>().WithMany().HasForeignKey(c => c.UpdatedById);
        }
    }
}
