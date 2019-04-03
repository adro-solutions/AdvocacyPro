using AdvocacyPro.Services.Base;
using AdvocacyPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvocacyPro.Data;
using Microsoft.EntityFrameworkCore;
using AdvocacyPro.Models.Exceptions;

namespace AdvocacyPro.Services
{
    public class CaseOffenderLogic : CaseChildBaseLogic<CaseOffender>
    {
        public CaseOffenderLogic(DataContext db) : base(db)
        {
        }

        public async override Task Update(int id, int caseId, int organizationId, int userId, CaseOffender item)
        {
            var result = await (from v in db.CaseOffender
                                join c in db.Case on v.CaseId equals c.Id
                                where v.Id == id
                                && v.CaseId == caseId
                                && c.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            
            result.Address = item.Address;
            result.Age = item.Age;
            result.CellPhone = item.CellPhone;
            result.City = item.City;
            result.DOB = item.DOB;
            result.Email = item.Email;
            result.EthnicityId = item.EthnicityId;
            result.FirstName = item.FirstName;
            result.GenderId = item.GenderId;
            result.HomePhone = item.HomePhone;
            result.LastName = item.LastName;
            result.MiddleName = item.MiddleName;
            result.RaceId = item.RaceId;
            result.StateId = item.StateId;
            result.UpdateDate = DateTime.UtcNow;
            result.UpdatedById = userId;
            result.WorkPhone = item.WorkPhone;
            result.AgeGroupingId = item.AgeGroupingId;
            result.Comments = item.Comments;
            result.NumberOfOffenses = item.NumberOfOffenses;
            result.PriorOffenses = item.PriorOffenses;
            result.RelationshipTypeId = item.RelationshipTypeId;
            result.ZipCode = item.ZipCode;


            await db.SaveChangesAsync();
        }
    }
}
