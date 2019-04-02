using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdvocacyPro.Models;
using AdvocacyPro.Models.Values;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AdvocacyPro.Models.Logging;
using AdvocacyPro.Models.Auth;
using Microsoft.AspNetCore.Identity;
using AdvocacyPro.Models.Utility;

namespace AdvocacyPro.Data
{
    public class DataContext : IdentityDbContext<User, Role, int>
    {
        public static bool Initialized { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Build models appropriately
            Models.Case.BuildModel(modelBuilder);
            Models.CaseContact.BuildModel(modelBuilder);
            Models.CaseDocument.BuildModel(modelBuilder);
            Models.CaseEmergencyContact.BuildModel(modelBuilder);
            Models.CaseIncident.BuildModel(modelBuilder);
            Models.CaseNote.BuildModel(modelBuilder);
            Models.CaseOffender.BuildModel(modelBuilder);
            Models.CasePolice.BuildModel(modelBuilder);
            Models.CaseReferral.BuildModel(modelBuilder);
            Models.CaseService.BuildModel(modelBuilder);
            Models.CaseWitness.BuildModel(modelBuilder);
            Models.Values.ServiceProgram.BuildModel(modelBuilder);
            Models.Values.Offense.BuildModel(modelBuilder);
            Models.Fire.BuildModel(modelBuilder);
            User.BuildModel(modelBuilder);
            Models.Values.Organization.BuildModel(modelBuilder);
            Models.Values.ZipCode.BuildModel(modelBuilder);
            Models.CaseCVCApplication.BuildModel(modelBuilder);
            Models.CasePayment.BuildModel(modelBuilder);
            Models.Values.OrganizationFeature.BuildModel(modelBuilder);
            Models.CaseProtectiveOrder.BuildModel(modelBuilder);
            Models.CaseLetter.BuildModel(modelBuilder);
            Models.CaseCourtDate.BuildModel(modelBuilder);
            Models.CaseVictimization.BuildModel(modelBuilder);
            Models.CaseInterview.BuildModel(modelBuilder);
            CaseInterviewDocumentationType.BuildModel(modelBuilder);

            //Set keys on the identity objects
            modelBuilder.Entity<IdentityUserLogin<int>>().HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
            modelBuilder.Entity<IdentityUserRole<int>>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<IdentityUserToken<int>>().HasKey(t => new { t.UserId, t.LoginProvider });

            //Set cascade options
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            
        }

        public DbSet<Country> Country { get; set; }
        public DbSet<AgeGrouping> AgeGrouping { get; set; }
        public DbSet<ContactType> ContactType { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<ReferralType> ReferralType { get; set; }
        public DbSet<ServiceCategory> ServiceCategory { get; set; }
        public DbSet<ServicePopulation> ServicePopulation { get; set; }
        public DbSet<ServiceProgram> ServiceProgram { get; set; }
        public DbSet<CaseCVCApplication> CaseCVCApplication { get; set; }
        public DbSet<CasePayment> CasePayment { get; set; }
        public DbSet<CaseProtectiveOrder> CaseProtectiveOrder { get; set; }
        public DbSet<CaseLetter> CaseLetter { get; set; }
        public DbSet<CaseCourtDate> CaseCourtDate { get; set; }
        public DbSet<CaseVictimization> CaseVictimization { get; set; }
        public DbSet<CaseInterview> CaseInterview { get; set; }
        public DbSet<Ethnicity> Ethnicity { get; set; }
        public DbSet<LocationType> LocationType { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<FireCause> FireCause { get; set; }
        public DbSet<Offense> Offense { get; set; }
        public DbSet<OffenseType> OffenseType { get; set; }
        public DbSet<OrganizationType> OrganizationType { get; set; }
        public DbSet<Race> Race { get; set; }
        public DbSet<RelationshipType> RelationshipType { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Case> Case { get; set; }
        public DbSet<User> Member { get; set; }
        public DbSet<Fire> Fire { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<OrganizationFeature> OrganizationFeature { get; set; }
        public DbSet<CaseContact> CaseContact { get; set; }
        public DbSet<CaseDocument> CaseDocument { get; set; }
        public DbSet<CaseEmergencyContact> CaseEmergencyContact { get; set; }
        public DbSet<CaseIncident> CaseIncident { get; set; }
        public DbSet<CaseNote> CaseNote { get; set; }
        public DbSet<CaseOffender> CaseOffender { get; set; }
        public DbSet<CasePolice> CasePolice { get; set; }
        public DbSet<CaseReferral> CaseReferral { get; set; }
        public DbSet<CaseService> CaseService { get; set; }
        public DbSet<CaseWitness> CaseWitness { get; set; }
        public DbSet<LogEntry> Log { get; set; }
        public DbSet<ZipCode> ZipCode { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatus { get; set; }
        public DbSet<PaymentCategory> PaymentCategory { get; set; }
        public DbSet<Payor> Payor { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<OrderType> OrderType { get; set; }
        public DbSet<LetterType> LetterType { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<DocketType> DocketType { get; set; }
        public DbSet<BondType> BondType { get; set; }
        public DbSet<VictimType> VictimType { get; set; }
        public DbSet<InterviewDocumentationType> InterviewDocumentationType { get; set; }
        public DbSet<InterviewerPosition> InterviewerPosition { get; set; }
        public DbSet<ObjectVersion> ObjectVersion { get; set; }
    }
}
