using AdvocacyPro.Models;
using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Constants;
using AdvocacyPro.Models.DTO;
using AdvocacyPro.Models.Values;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AdvocacyPro.Data
{
    public static class DataInitialization
    {
        public static async Task Seed(DataContext db)
        {
            if (!db.OrganizationType.Any())
                await db.OrganizationType.AddRangeAsync(OrganizationType.Seed());

            if (!db.OffenseType.Any())
                await db.OffenseType.AddRangeAsync(OffenseType.Seed());

            if (!db.ServiceCategory.Any())
                await db.ServiceCategory.AddRangeAsync(ServiceCategory.Seed());

            // the previous entries must exist before we can continue!
            if (db.ChangeTracker.HasChanges())
                await db.SaveChangesAsync();

            if (!db.Organization.Any())
            {
                await db.Organization.AddAsync(new Organization()
                {
                    Name = "Adro Solutions, LLC",
                    Email = "adam.amrine@adrosolutions.com",
                    TypeId = db.OrganizationType.First(oType => oType.Name == "Admin").Id
                });

                await db.SaveChangesAsync();
            }

            var features = new ProductFeatures();
            var org = db.Organization.FirstOrDefault(o => o.Name == "Adro Solutions, LLC");
            if (org != null)
            {
                var orgFeatures = db.OrganizationFeature.Where(of => of.OrganizationId == org.Id).ToList();
                foreach (FieldInfo fi in typeof(ProductFeatures).GetFields())
                {
                    var value = fi.GetValue(features) as string;
                    if (!orgFeatures.Any(of => of.Value == value))
                        db.OrganizationFeature.Add(new OrganizationFeature() { OrganizationId = org.Id, Value = value });
                }
            }

            if (!db.PaymentCategory.Any())
                await db.PaymentCategory.AddRangeAsync(PaymentCategory.Seed());

            if (!db.Payor.Any())
                await db.Payor.AddRangeAsync(Payor.Seed());

            if (!db.OrderStatus.Any())
                await db.OrderStatus.AddRangeAsync(OrderStatus.Seed());

            if (!db.OrderType.Any())
                await db.OrderType.AddRangeAsync(OrderType.Seed());

            if (!db.LetterType.Any())
                await db.LetterType.AddRangeAsync(LetterType.Seed());

            if (!db.Language.Any())
                await db.Language.AddRangeAsync(Language.Seed());

            if (!db.DocketType.Any())
                await db.DocketType.AddRangeAsync(DocketType.Seed());

            if (!db.BondType.Any())
                await db.BondType.AddRangeAsync(BondType.Seed());

            if (!db.VictimType.Any())
                await db.VictimType.AddRangeAsync(VictimType.Seed());

            if (!db.InterviewDocumentationType.Any())
                await db.InterviewDocumentationType.AddRangeAsync(InterviewDocumentationType.Seed());

            if (!db.InterviewerPosition.Any())
                await db.InterviewerPosition.AddRangeAsync(InterviewerPosition.Seed());

            if (!db.ApplicationStatus.Any())
                await db.ApplicationStatus.AddRangeAsync(ApplicationStatus.Seed());

            if (!db.Country.Any())
                await db.Country.AddRangeAsync(Country.Seed());

            if (!db.AgeGrouping.Any())
                await db.AgeGrouping.AddRangeAsync(AgeGrouping.Seed());

            if (!db.ContactType.Any())
                await db.ContactType.AddRangeAsync(ContactType.Seed());

            if (!db.DocumentType.Any())
                await db.DocumentType.AddRangeAsync(DocumentType.Seed());

            if (!db.ReferralType.Any()) // referral reason??
                await db.ReferralType.AddRangeAsync(ReferralType.Seed());

            if (!db.ServicePopulation.Any())
                await db.ServicePopulation.AddRangeAsync(ServicePopulation.Seed());

            if (!db.ServiceProgram.Any())
            {
                ServiceCategory residentialServices = db.ServiceCategory.First(o => o.Name == "Residential Services");
                ServiceCategory dayServices = db.ServiceCategory.First(o => o.Name == "Day Services");
                ServiceCategory behaviorServices = db.ServiceCategory.First(o => o.Name == "Behavior Services");
                ServiceCategory mentalHealthServices = db.ServiceCategory.First(o => o.Name == "Mental Health Services");
                ServiceCategory employmentServices = db.ServiceCategory.First(o => o.Name == "Employment Services");
                ServiceCategory outsideAgency = db.ServiceCategory.First(o => o.Name == "Referal to Outside Agencies / Resources");
                ServiceCategory medicalServices = db.ServiceCategory.First(o => o.Name == "Medical Services");
                ServiceCategory schoolServices = db.ServiceCategory.First(o => o.Name == "School Services");
                ServiceCategory other = db.ServiceCategory.First(o => o.Name == "Other");

                await db.ServiceProgram.AddRangeAsync(new ServiceProgram { Name = "Group Home SGL", CategoryId = residentialServices.Id },
                    new ServiceProgram { Name = "Supported Living SLP", CategoryId = residentialServices.Id },
                    new ServiceProgram { Name = "Respite", CategoryId = residentialServices.Id },
                    new ServiceProgram { Name = "Personal Assistance Care (PAC)", CategoryId = residentialServices.Id },
                    new ServiceProgram { Name = "Lifelong Learning", CategoryId = dayServices.Id },
                    new ServiceProgram { Name = "Manufacturing", CategoryId = dayServices.Id },
                    new ServiceProgram { Name = "Personal Assistance Care (PAC)", CategoryId = dayServices.Id },
                    new ServiceProgram { Name = "Behavior Services", CategoryId = behaviorServices.Id },
                    new ServiceProgram { Name = "Milestones Outpatient", CategoryId = mentalHealthServices.Id },
                    new ServiceProgram { Name = "Crisis Intervention", CategoryId = mentalHealthServices.Id },
                    new ServiceProgram { Name = "Crisis Stabilization", CategoryId = mentalHealthServices.Id },
                    new ServiceProgram { Name = "Response Education", CategoryId = mentalHealthServices.Id },
                    new ServiceProgram { Name = "SANE", CategoryId = mentalHealthServices.Id },
                    new ServiceProgram { Name = "SASS", CategoryId = mentalHealthServices.Id },
                    new ServiceProgram { Name = "OSP", CategoryId = mentalHealthServices.Id },
                    new ServiceProgram { Name = "CARDV", CategoryId = mentalHealthServices.Id },
                    new ServiceProgram { Name = "Community Employment", CategoryId = employmentServices.Id },
                    new ServiceProgram { Name = "Project Search", CategoryId = employmentServices.Id },
                    new ServiceProgram { Name = "Self Advocates", CategoryId = employmentServices.Id },
                    new ServiceProgram { Name = "Job Club", CategoryId = employmentServices.Id },
                    new ServiceProgram { Name = "Social Security", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Food Stamps", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Township Trustee", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Private Therapist", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Agency on Aging", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Vocational Rehab", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Emergency Housing", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Housing", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Arc of Indiana", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Community Support Group", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Probono Legal Resources", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Medicaid", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "BDDS", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Adult Protective Services", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Child Protective Services", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Guardianship / Advocacy Services", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Case Manager BDDS", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Referral Where", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Police (Non Campus)", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Stalking order / SAPO / Restraining Order", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Crime Victim Compensation", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Shelter", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Legal Assistance", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Court Proceedings", CategoryId = outsideAgency.Id },
                    new ServiceProgram { Name = "Hospital", CategoryId = medicalServices.Id },
                    new ServiceProgram { Name = "OEI collaboration", CategoryId = schoolServices.Id },
                    new ServiceProgram { Name = "Student conduct", CategoryId = schoolServices.Id },
                    new ServiceProgram { Name = "Housing Accommodations", CategoryId = schoolServices.Id },
                    new ServiceProgram { Name = "Registrar Accommodations", CategoryId = schoolServices.Id },
                    new ServiceProgram { Name = "Academic Accommodations", CategoryId = schoolServices.Id },
                    new ServiceProgram { Name = "Letters of support", CategoryId = schoolServices.Id },
                    new ServiceProgram { Name = "Other", CategoryId = other.Id });
            }

            if (!db.Ethnicity.Any())
                await db.Ethnicity.AddRangeAsync(Ethnicity.Seed());

            if (!db.LocationType.Any())
                await db.LocationType.AddRangeAsync(LocationType.Seed());

            if (!db.Gender.Any())
                await db.Gender.AddRangeAsync(Gender.Seed());

            if (!db.FireCause.Any())
            {
                await db.FireCause.AddRangeAsync(FireCause.Seed());
            }

            if (!db.Offense.Any())
            {
                OffenseType criminal = db.OffenseType.First(o => o.Name == "Criminal Offenses");
                OffenseType hateCrimes = db.OffenseType.First(o => o.Name == "Hate Crimes");
                OffenseType arrestsReferrals = db.OffenseType.First(o => o.Name == "Arrests and Referrals");
                OffenseType other = db.OffenseType.First(o => o.Name == "other");

                await db.Offense.AddRangeAsync(new Offense { Name = "Murder / Non - Negligent Manslaughter", TypeId = criminal.Id, CleryReport = true },
                    new Offense { Name = "Negligent Manslaughter", TypeId = criminal.Id, CleryReport = true },
                    new Offense { Name = "Sex Offenses -Forcible", TypeId = criminal.Id, CleryReport = true },
                    new Offense { Name = "Sex Offenses -Non Forcible", TypeId = criminal.Id, CleryReport = true },
                    new Offense { Name = "Robbery", TypeId = criminal.Id, CleryReport = true },
                    new Offense { Name = "Aggrivated Assault", TypeId = criminal.Id, CleryReport = true },
                    new Offense { Name = "Burglary", TypeId = criminal.Id, CleryReport = true },
                    new Offense { Name = "Motor Vehicle Theft", TypeId = criminal.Id, CleryReport = true },
                    new Offense { Name = "Arson", TypeId = criminal.Id, CleryReport = true },
                    new Offense { Name = "Arrest: Weapons: Carrying Posession", TypeId = arrestsReferrals.Id, CleryReport = true },
                    new Offense { Name = "Disciplinary Referrals: Weapons: Carrying Posession", TypeId = arrestsReferrals.Id, CleryReport = true },
                    new Offense { Name = "Arrests: Drug Abuse Violations", TypeId = arrestsReferrals.Id, CleryReport = true },
                    new Offense { Name = "Disciplinary Referrals: Drug Abuse Violations", TypeId = arrestsReferrals.Id, CleryReport = true },
                    new Offense { Name = "Arrests: Liquor Law Violations", TypeId = arrestsReferrals.Id, CleryReport = true },
                    new Offense { Name = "Disciplinary Referrals: Liquor Law Violations", TypeId = arrestsReferrals.Id, CleryReport = true },
                    new Offense { Name = "Stalking", TypeId = other.Id, CleryReport = false },
                    new Offense { Name = "Bullying or Hazing", TypeId = other.Id, CleryReport = false },
                    new Offense { Name = "Sexual Harassment", TypeId = other.Id, CleryReport = false },
                    new Offense { Name = "Dating Violence", TypeId = other.Id, CleryReport = false },
                    new Offense { Name = "Domestic Violence", TypeId = other.Id, CleryReport = false });
            }

            if (!db.Race.Any())
                await db.Race.AddRangeAsync(Race.Seed());

            if (!db.RelationshipType.Any())
                await db.RelationshipType.AddRangeAsync(RelationshipType.Seed());

            if (!db.State.Any())
                await db.State.AddRangeAsync(State.Seed());

            if (!db.Status.Any())
                await db.Status.AddRangeAsync(Status.Seed());

            if (!db.ZipCode.Any())
                await db.ZipCode.AddRangeAsync(ZipCode.Seed());

            if (db.ChangeTracker.HasChanges())
                db.SaveChanges();
        }

        public static async Task SeedAdmin(UserManager<User> userManager, RoleManager<Role> roleManager, int organizationId)
        {
            var user = await userManager.FindByNameAsync("adam.amrine@adrosolutions.com");
            if (user == null)
            {
                await userManager.CreateAsync(new User()
                {
                    FirstName = "Adam",
                    LastName = "Amrine",
                    Email = "adam.amrine@adrosolutions.com",
                    UserName = "adam.amrine@adrosolutions.com",
                    OrganizationId = organizationId
                }, generatePassword());

                user = await userManager.FindByNameAsync("adam.amrine@adrosolutions.com");
            }

            var user2 = await userManager.FindByNameAsync("josh.knack@adrosolutions.com");
            if (user2 == null)
            {
                await userManager.CreateAsync(new User()
                {
                    FirstName = "Josh",
                    LastName = "Knack",
                    Email = "josh.knack@adrosolutions.com",
                    UserName = "josh.knack@adrosolutions.com",
                    OrganizationId = organizationId
                }, generatePassword());

                user2 = await userManager.FindByNameAsync("josh.knack@adrosolutions.com");

            }

            var uc = await userManager.GetClaimsAsync(user);
            var uc2 = await userManager.GetClaimsAsync(user2);
            var features = new ProductFeatures();
            foreach (FieldInfo fi in typeof(ProductFeatures).GetFields())
            {
                var value = fi.GetValue(features) as string;
                if (!uc.Any(c => c.Type == ProductFeaturesClaimType.Value && c.Value == value))
                    await userManager.AddClaimAsync(user, new System.Security.Claims.Claim(ProductFeaturesClaimType.Value, value));

                if (!uc2.Any(c => c.Type == ProductFeaturesClaimType.Value && c.Value == value))
                    await userManager.AddClaimAsync(user2, new System.Security.Claims.Claim(ProductFeaturesClaimType.Value, value));
            }

        }

        private static string generatePassword()
        {
            Random random = new Random();
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string special = "!@#$%^&*";

            string pw = new string(Enumerable.Repeat(lower, 3)
              .Select(s => s[random.Next(s.Length)]).ToArray()) +
              new string(Enumerable.Repeat(upper, 3)
              .Select(s => s[random.Next(s.Length)]).ToArray()) +
              new string(Enumerable.Repeat(numbers, 3)
              .Select(s => s[random.Next(s.Length)]).ToArray()) +
              new string(Enumerable.Repeat(special, 3)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return pw;
        }
    }
}
