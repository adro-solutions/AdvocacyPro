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
    public class CasePaymentLogic : CaseChildBaseLogic<CasePayment>
    {
        public CasePaymentLogic(DataContext db) : base(db)
        {
        }

        public async override Task Update(int id, int caseId, int organizationId, int userId, CasePayment item)
        {
            var result = await (from v in db.CasePayment
                                join c in db.Case on v.CaseId equals c.Id
                                where v.Id == id
                                && v.CaseId == caseId
                                && c.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            result.AmountApproved = item.AmountApproved;
            result.AmountSubmitted = item.AmountSubmitted;
            result.ApprovedById = item.ApprovedById;
            result.ApprovedDate = item.ApprovedDate;
            result.ClaimId = item.ClaimId;
            result.Comments = item.Comments;
            result.PaymentCategoryId = item.PaymentCategoryId;
            result.PayorId = item.PayorId;
            result.UpdateDate = DateTime.UtcNow;
            result.UpdatedById = userId;


            await db.SaveChangesAsync();
        }
    }
}
