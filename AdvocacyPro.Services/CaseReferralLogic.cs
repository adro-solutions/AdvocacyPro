using AdvocacyPro.Services.Base;
using AdvocacyPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvocacyPro.Data;
using AdvocacyPro.Models.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AdvocacyPro.Services
{
    public class CaseReferralLogic : CaseChildBaseLogic<CaseReferral>
    {
        public CaseReferralLogic(DataContext db) : base(db)
        {
        }

        public async override Task Update(int id, int caseId, int organizationId, int userId, CaseReferral item)
        {
            var result = await (from v in db.CaseReferral
                                join c in db.Case on v.CaseId equals c.Id
                                where v.Id == id
                                && v.CaseId == caseId
                                && c.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();


            result.Contact = item.Contact;
            result.ContactDate = item.ContactDate;
            result.FollowupDate = item.FollowupDate;
            result.Notes = item.Notes;
            result.Source = item.Source;
            result.TypeId = item.TypeId;
            result.UpdateDate = DateTime.UtcNow;
            result.UpdatedById = userId;

            await db.SaveChangesAsync();
        }
    }
}
