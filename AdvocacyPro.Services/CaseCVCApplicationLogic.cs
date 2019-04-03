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
    public class CaseCVCApplicationLogic : CaseChildBaseLogic<CaseCVCApplication>
    {
        public CaseCVCApplicationLogic(DataContext db) : base(db)
        {
        }

        public async override Task Update(int id, int caseId, int organizationId, int userId, CaseCVCApplication item)
        {
            var result = await (from v in db.CaseCVCApplication
                                join c in db.Case on v.CaseId equals c.Id
                                where v.Id == id
                                && v.CaseId == caseId
                                && c.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            result.ApplicationStatusId = item.ApplicationStatusId;
            result.CVCDate = item.CVCDate;
            result.CVCNumber = item.CVCNumber;
            result.Defendant = item.Defendant;
            result.OffenseTypeId = item.OffenseTypeId;
            result.ReferralOther = item.ReferralOther;
            result.ReferralTypeId = item.ReferralTypeId;
            result.Notes = item.Notes;
            result.UpdateDate = DateTime.UtcNow;
            result.UpdatedById = userId;


            await db.SaveChangesAsync();
        }
    }
}
