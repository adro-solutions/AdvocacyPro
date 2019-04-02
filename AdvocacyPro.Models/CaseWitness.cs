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
    public class CaseWitness : ContactBase, ICaseChild
    {
        public int Id { get; set; }
        public int CaseId { get; set; }


        public DateTime InterviewDate { get; set; }
        
        public int? RelationshipTypeId { get; set; }

        public string Notes { get; set; }
        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseWitness>().Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<CaseWitness>().HasOne<RelationshipType>().WithMany().HasForeignKey(c => c.RelationshipTypeId);
            modelBuilder.Entity<CaseWitness>().HasOne<Case>().WithMany(c => c.Witnesses).HasForeignKey(c => c.CaseId);
            modelBuilder.Entity<CaseWitness>().HasOne<User>().WithMany().HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<CaseWitness>().HasOne<User>().WithMany().HasForeignKey(c => c.UpdatedById);
            modelBuilder.Entity<CaseWitness>().HasOne<Race>().WithMany().HasForeignKey(c => c.RaceId);
            modelBuilder.Entity<CaseWitness>().HasOne<Ethnicity>().WithMany().HasForeignKey(c => c.EthnicityId);
            modelBuilder.Entity<CaseWitness>().HasOne<Gender>().WithMany().HasForeignKey(c => c.GenderId);
            modelBuilder.Entity<CaseWitness>().HasOne<State>().WithMany().HasForeignKey(c => c.StateId);
        }
    }
}
