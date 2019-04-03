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
    public class CasePoliceLogic : CaseChildBaseLogic<CasePolice>
    {
        public CasePoliceLogic(DataContext db) : base(db)
        {
        }

        public async override Task Update(int id, int caseId, int organizationId, int userId, CasePolice item)
        {
            var result = await (from v in db.CasePolice
                                join c in db.Case on v.CaseId equals c.Id
                                where v.Id == id
                                && v.CaseId == caseId
                                && c.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();


            result.FirstName = item.FirstName;
            result.LastName = item.LastName;
            result.Notes = item.Notes;
            result.PoliceCaseNo = item.PoliceCaseNo;
            result.PoliceClosedDate = item.PoliceClosedDate;
            result.PoliceDepartment = item.PoliceDepartment;
            result.PoliceOutcome = item.PoliceOutcome;
            result.PoliceSequenceNo = item.PoliceSequenceNo;
            result.UpdateDate = DateTime.UtcNow;
            result.UpdatedById = userId;

            await db.SaveChangesAsync();
        }
    }
}
