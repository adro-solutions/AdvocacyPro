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
    public class CaseServiceLogic : CaseChildBaseLogic<CaseService>
    {
        public CaseServiceLogic(DataContext db) : base(db)
        {
        }

        public async override Task Update(int id, int caseId, int organizationId, int userId, CaseService item)
        {
            var result = await (from v in db.CaseService
                                join c in db.Case on v.CaseId equals c.Id
                                where v.Id == id
                                && v.CaseId == caseId
                                && c.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();


            result.CategoryId = item.CategoryId;
            result.EndDate = item.EndDate;
            result.Notes = item.Notes;
            result.PopulationId = item.PopulationId;
            result.ProgramId = item.ProgramId;
            result.StartDate = item.StartDate;
            result.UpdateDate = DateTime.UtcNow;
            result.UpdatedById = userId;

            await db.SaveChangesAsync();
        }
    }
}
