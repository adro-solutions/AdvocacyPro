using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Base;
using AdvocacyPro.Models.Values;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models
{
    public class CaseEmergencyContact : ContactBase, ICaseChild
    {
        public int Id { get; set; }

        public int CaseId { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseEmergencyContact>().Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<CaseEmergencyContact>().HasOne<Case>().WithMany(c => c.EmergencyContacts).HasForeignKey(c => c.CaseId);
            modelBuilder.Entity<CaseEmergencyContact>().HasOne<User>().WithMany().HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<CaseEmergencyContact>().HasOne<User>().WithMany().HasForeignKey(c => c.UpdatedById);
            modelBuilder.Entity<CaseEmergencyContact>().HasOne<Race>().WithMany().HasForeignKey(c => c.RaceId);
            modelBuilder.Entity<CaseEmergencyContact>().HasOne<Ethnicity>().WithMany().HasForeignKey(c => c.EthnicityId);
            modelBuilder.Entity<CaseEmergencyContact>().HasOne<Gender>().WithMany().HasForeignKey(c => c.GenderId);
            modelBuilder.Entity<CaseEmergencyContact>().HasOne<State>().WithMany().HasForeignKey(c => c.StateId);
        }
    }
}
