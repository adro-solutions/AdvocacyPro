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
    public class CaseOffender : ContactBase, ICaseChild
    {
        public int Id { get; set; }
        public int CaseId { get; set; }

        public Boolean PriorOffenses { get; set; }
        [Range(0,100)]
        [Display(Name = "Number of offenses")]
        public int? NumberOfOffenses { get; set; }

        public int? RelationshipTypeId {get;set;}
        
        public string Comments { get; set; }

        public int? AgeGroupingId { get; set; }
        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseOffender>().Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<CaseOffender>().HasOne<AgeGrouping>().WithMany().HasForeignKey(c => c.AgeGroupingId);
            modelBuilder.Entity<CaseOffender>().HasOne<RelationshipType>().WithMany().HasForeignKey(c => c.RelationshipTypeId);
            modelBuilder.Entity<CaseOffender>().HasOne<Case>().WithMany(c => c.Offenders).HasForeignKey(c => c.CaseId);
            modelBuilder.Entity<CaseOffender>().HasOne<User>().WithMany().HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<CaseOffender>().HasOne<User>().WithMany().HasForeignKey(c => c.UpdatedById);
            modelBuilder.Entity<CaseOffender>().HasOne<Race>().WithMany().HasForeignKey(c => c.RaceId);
            modelBuilder.Entity<CaseOffender>().HasOne<Ethnicity>().WithMany().HasForeignKey(c => c.EthnicityId);
            modelBuilder.Entity<CaseOffender>().HasOne<Gender>().WithMany().HasForeignKey(c => c.GenderId);
            modelBuilder.Entity<CaseOffender>().HasOne<State>().WithMany().HasForeignKey(c => c.StateId);
        }
    }
}
