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
    public class Case : ContactBase
    {
        public int Id { get; set; }
        
        public bool Archived { get; set; }
        public DateTime CaseDate { get; set; }

        public int OrganizationId { get; set;  }

        public int? StaffUserId { get; set; }
        public int StatusId { get; set; }

        public List<CaseIncident> Incidents { get; set; }

        public List<CaseEmergencyContact> EmergencyContacts { get; set; }

        public List<CaseReferral> Referrals { get; set; }

        public List<CaseService> Services { get; set; }

        public List<CaseNote> Notes { get; set; }

        public List<CaseContact> ContactLog { get; set; }

        public List<CaseDocument> Documents { get; set; }

        public List<CaseWitness> Witnesses { get; set; }

        public List<CasePolice> Police { get; set; }

        public List<CaseOffender> Offenders { get; set; }

        public List<CaseCVCApplication> CVCApplications { get; set; }

        public List<CasePayment> Payments { get; set; }

        public List<CaseProtectiveOrder> ProtectiveOrders { get; set; }

        public List<CaseLetter> Letters { get; set; }

        public List<CaseCourtDate> CourtDates { get; set; }

        public List<CaseVictimization> Victimizations { get; set; }

        public List<CaseInterview> Interviews { get; set; }

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Case>().Property(c => c.CreateDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<Case>().HasOne<Organization>().WithMany().HasForeignKey(c => c.OrganizationId);
            modelBuilder.Entity<Case>().HasOne<User>().WithMany().HasForeignKey(c => c.CreatedById);
            modelBuilder.Entity<Case>().HasOne<User>().WithMany().HasForeignKey(c => c.UpdatedById);
            modelBuilder.Entity<Case>().HasOne<Race>().WithMany().HasForeignKey(c => c.RaceId);
            modelBuilder.Entity<Case>().HasOne<Ethnicity>().WithMany().HasForeignKey(c => c.EthnicityId);
            modelBuilder.Entity<Case>().HasOne<Gender>().WithMany().HasForeignKey(c => c.GenderId);
            modelBuilder.Entity<Case>().HasOne<State>().WithMany().HasForeignKey(c => c.StateId);
            modelBuilder.Entity<Case>().HasOne<User>().WithMany().HasForeignKey(c => c.StaffUserId);
            modelBuilder.Entity<Case>().HasOne<Status>().WithMany().HasForeignKey(c => c.StatusId);
        }
    }
}
