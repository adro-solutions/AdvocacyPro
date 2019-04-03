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
    public class CaseProtectiveOrderLogic : CaseChildBaseLogic<CaseProtectiveOrder>
    {
        public CaseProtectiveOrderLogic(DataContext db) : base(db)
        {
        }

        public async override Task Update(int id, int caseId, int organizationId, int userId, CaseProtectiveOrder item)
        {
            var result = await (from v in db.CaseProtectiveOrder
                                join c in db.Case on v.CaseId equals c.Id
                                where v.Id == id
                                && v.CaseId == caseId
                                && c.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            result.EndDate = item.EndDate;
            result.Notes = item.Notes;
            result.OrderStatusId = item.OrderStatusId;
            result.OrderTypeId = item.OrderTypeId;
            result.StartDate = item.StartDate;
            result.UpdateDate = DateTime.UtcNow;
            result.UpdatedById = userId;


            await db.SaveChangesAsync();
        }
    }
}
