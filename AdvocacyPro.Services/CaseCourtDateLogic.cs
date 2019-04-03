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
    public class CaseCourtDateLogic : CaseChildBaseLogic<CaseCourtDate>
    {
        public CaseCourtDateLogic(DataContext db) : base(db)
        {
        }

        public async override Task Update(int id, int caseId, int organizationId, int userId, CaseCourtDate item)
        {
            var result = await (from v in db.CaseCourtDate
                                join c in db.Case on v.CaseId equals c.Id
                                where v.Id == id
                                && v.CaseId == caseId
                                && c.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            result.ArrestDate = item.ArrestDate;
            result.BondAmount = item.BondAmount;
            result.BondTypeId = item.BondTypeId;
            result.Court = item.Court;
            result.DocketNumber = item.DocketNumber;
            result.DocketTypeId = item.DocketTypeId;
            result.EndDate = item.EndDate;
            result.Police = item.Police;
            result.Purpose = item.Purpose;
            result.Reason = item.Reason;
            result.StartDate = item.StartDate;
            result.UpdateDate = DateTime.UtcNow;
            result.UpdatedById = userId;


            await db.SaveChangesAsync();
        }
    }
}
