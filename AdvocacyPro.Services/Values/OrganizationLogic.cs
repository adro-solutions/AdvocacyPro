using AdvocacyPro.Data;
using AdvocacyPro.Services.Auth;
using AdvocacyPro.Services.Base;
using AdvocacyPro.Services.Utility;
using AdvocacyPro.Models;
using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Constants;
using AdvocacyPro.Models.DTO;
using AdvocacyPro.Models.Exceptions;
using AdvocacyPro.Models.Result;
using AdvocacyPro.Models.Values;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdvocacyPro.Services.Values
{
    public class OrganizationLogic : ValueBaseLogic<Organization>
    {
        UserManager<User> userManager;
        RoleManager<Role> roleManager;
        FeatureLogic fLogic;
        ObjectLogic objectLogic;

        public OrganizationLogic(DataContext db, UserManager<User> userManager, 
            RoleManager<Role> roleManager, FeatureLogic fLogic, ObjectLogic objectLogic) : base(db, objectLogic)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.fLogic = fLogic;
            this.objectLogic = objectLogic;
        }
        
        public override async Task Update(int id, Organization item)
        {
            var result = await (from v in db.Organization
                                where v.Id == item.Id
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            result.Address1 = item.Address1;
            result.Address2 = item.Address2;
            result.Address3 = item.Address3;
            result.City = item.City;
            result.Description = item.Description;
            result.Email = item.Email;
            result.Fax = item.Fax;
            result.LastModifiedDate = DateTime.UtcNow;
            result.Name = item.Name;
            result.Phone = item.Phone;
            result.PrimaryContact = item.PrimaryContact;
            result.State = item.State;
            result.TypeId = item.TypeId;
            result.Url = item.Url;
            result.ZipCode = item.ZipCode;
            result.Product = item.Product;

            await db.SaveChangesAsync();
            await objectLogic.LogVersion<Organization>();
        }

        public async Task<List<MemberData>> GetUsers(int organizationId)
        {
           var members = from member in db.Member
                        where member.OrganizationId == organizationId
                    select new MemberData
                    {
                        Id = member.Id,
                        FirstName = member.FirstName,
                        LastName = member.LastName,
                        Email = member.Email,
                        OrganizationId = member.OrganizationId,
                        Password = "n0t_Returned!"
                    };

            return await members.ToListAsync();
        }

        public async Task<MemberData> GetUser(int organizationId, int userId)
        {
            var members = from member in db.Member
                          where member.OrganizationId == organizationId && member.Id == userId
                          select new MemberData
                          {
                              Id = member.Id,
                              FirstName = member.FirstName,
                              LastName = member.LastName,
                              Email = member.Email,
                              OrganizationId = member.OrganizationId,
                              Password = "n0t_Returned!"
                          };

            return await members.FirstOrDefaultAsync();
        }

        public async Task<MemberData> UpdateUser(int organizationId, int userId, MemberData member)
        {
            User m = await db.Member.FirstOrDefaultAsync(mem => mem.Id == userId && mem.OrganizationId == organizationId);

            if (m != null)
            {
                m.FirstName = member.FirstName;
                m.LastName = member.LastName;
                m.Email = member.Email;
                m.UserName = member.Email;
            }

            await db.SaveChangesAsync();
            return await GetUser(organizationId, userId);
        }

        public async Task<CreateUserResult> CreateUser(int organizationId, MemberData member)
        {
            User m = new User();
            CreateUserResult returnResult = new CreateUserResult();
            returnResult.Success = false;

            m.FirstName = member.FirstName;
            m.LastName = member.LastName;
            m.Email = member.Email;
            m.UserName = member.Email;
            m.OrganizationId = organizationId;

            IdentityResult result = await userManager.CreateAsync(m, member.Password);
            
            if (result.Succeeded)
            {
                returnResult.Success = true;
                returnResult.CreatedUser = await GetUser(organizationId, m.Id);
            }
            else
            {
                if (result.Errors.Any(e => e.Code == "DuplicateUsername"))
                    returnResult.FailureReason = CreateUserFailure.DuplicateUser;
            }
            return returnResult;
        }

        public async Task DeleteUser(int organizationId, int userId)
        {
            User m = await db.Member.FirstOrDefaultAsync(mem => mem.Id == userId && mem.OrganizationId == organizationId);

            db.Entry(m).State = EntityState.Deleted;

            await db.SaveChangesAsync();
        }

        public async Task<Organization> Upload(int organizationId, byte[] file)
        {
            var result = await (from v in db.Organization
                                where v.Id == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            result.Logo = file;

            await db.SaveChangesAsync();
            return result;
        }

        public async Task<List<Feature>> GetUserFeatures(int organizationId, int userId)
        {
            User m = await db.Member.FirstOrDefaultAsync(mem => mem.Id == userId && mem.OrganizationId == organizationId);

            var claims = await userManager.GetClaimsAsync(m);

            var results = (from c in claims
                          select new Feature() { Value = c.Value }).ToList();

            return results;
        }

        public async Task UpdateUserFeatures(int organizationId, int userId, List<Feature> features)
        {
            User m = await db.Member.FirstOrDefaultAsync(mem => mem.Id == userId && mem.OrganizationId == organizationId);

            var claims = await userManager.GetClaimsAsync(m);
            var claimsToDelete = claims.Where(c => !features.Any(c2 => c2.Value == c.Value)).ToList();

            if (claimsToDelete.Count > 0)
                await userManager.RemoveClaimsAsync(m, claimsToDelete);

            var claimsToAdd = features.Where(f => !claims.Any(c => c.Value == f.Value)).ToList();

            if (claimsToAdd.Count > 0)
            { 
                List<Claim> convertedClaims = new List<Claim>();
                claimsToAdd.ForEach(c => convertedClaims.Add(new Claim(ProductFeaturesClaimType.Value, c.Value)));
                await userManager.AddClaimsAsync(m, convertedClaims);
            }
        }

        public async Task<List<Feature>> GetFeatures(int organizationId)
        {
            var features = fLogic.GetAll();

            var results = from f in db.OrganizationFeature
                                 where f.OrganizationId == organizationId
                                 select new Feature() { Value = f.Value, Name = features.First(feat => feat.Value == f.Value).Name };

            return await results.ToListAsync();
        }

        public async Task UpdateFeatures(int organizationId, List<OrganizationFeature> features)
        {
            var results = await (from f in db.OrganizationFeature
                                 where f.OrganizationId == organizationId
                                 select f).ToListAsync();

            var featuresToDelete = results.Where(f => !features.Any(f2 => f2.Value == f.Value));
            foreach (var f in featuresToDelete)
            {
                db.Entry(f).State = EntityState.Deleted;

                var orgResults = await (from uc in db.UserClaims
                                  join u in db.Users on uc.UserId equals u.Id
                                  where u.OrganizationId == organizationId
                                  && uc.ClaimValue == f.Value
                                  select uc).ToListAsync();

                db.UserClaims.RemoveRange(orgResults);
            }
            var featuresToAdd = features.Where(f => !results.Any(f2 => f2.Value == f.Value)).ToList();
            featuresToAdd.ForEach(f => f.OrganizationId = organizationId);
            db.OrganizationFeature.AddRange(featuresToAdd);
            await db.SaveChangesAsync();
        }
    }
}
