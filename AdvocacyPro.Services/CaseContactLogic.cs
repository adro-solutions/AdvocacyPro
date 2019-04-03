using AdvocacyPro.Data;
using AdvocacyPro.Services.Base;
using AdvocacyPro.Models;
using AdvocacyPro.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Services
{
    public class CaseContactLogic : CaseChildBaseLogic<CaseContact>
    {
        public CaseContactLogic(DataContext db) : base(db)
        {
        }

        public async override Task Update(int id, int caseId, int organizationId, int userId, CaseContact item)
        {
            var result = await (from v in db.CaseContact
                               join c in db.Case on v.CaseId equals c.Id
                               where v.Id == id
                               && v.CaseId == caseId
                               && c.OrganizationId == organizationId
                               select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            result.ContactDate = item.ContactDate;
            result.ContactTypeId = item.ContactTypeId;
            result.UpdateDate = DateTime.UtcNow;
            result.UpdatedById = userId;
            result.Notes = item.Notes;
            

            await db.SaveChangesAsync();
        }
    }
}
