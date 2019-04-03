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
    public class CaseVictimizationLogic : CaseChildBaseLogic<CaseVictimization>
    {
        public CaseVictimizationLogic(DataContext db) : base(db)
        {
        }

        public async override Task Update(int id, int caseId, int organizationId, int userId, CaseVictimization item)
        {
            var result = await (from v in db.CaseVictimization
                                join c in db.Case on v.CaseId equals c.Id
                                where v.Id == id
                                && v.CaseId == caseId
                                && c.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            result.Comments = item.Comments;
            result.ReportDetails = item.ReportDetails;
            result.ReportingAgency = item.ReportingAgency;
            result.ReportNumber = item.ReportNumber;
            result.StartDate = item.StartDate;
            result.VictimTypeId = item.VictimTypeId;
            result.UpdateDate = DateTime.UtcNow;
            result.UpdatedById = userId;


            await db.SaveChangesAsync();
        }
    }
}
