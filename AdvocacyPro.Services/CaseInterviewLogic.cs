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
    public class CaseInterviewLogic : CaseChildBaseLogic<CaseInterview>
    {
        public CaseInterviewLogic(DataContext db) : base(db) { }

        public override async Task<List<CaseInterview>> Get(int caseId, int organizationId)
        {
            return await (from v in db.CaseInterview.Include(ci => ci.CaseInterviewDocumentationTypes)
                          join c in db.Case on v.CaseId equals c.Id
                          where v.CaseId == caseId
                          && c.OrganizationId == organizationId
                          select v).ToListAsync();
        }

        public override async Task<CaseInterview> Get(int id, int caseId, int organizationId)
        {
            var result = await (from v in db.CaseInterview.Include(ci => ci.CaseInterviewDocumentationTypes)
                                join c in db.Case on v.CaseId equals c.Id
                                where v.Id == id
                                && v.CaseId == caseId
                                && c.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            return result;
        }


        public async override Task Update(int id, int caseId, int organizationId, int userId, CaseInterview item)
        {
            var result = await (from v in db.CaseInterview.Include(i => i.CaseInterviewDocumentationTypes)
                                join c in db.Case on v.CaseId equals c.Id
                                where v.Id == id
                                && v.CaseId == caseId
                                && c.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            result.InterviewDate = item.InterviewDate;
            result.InterviewerName = item.InterviewerName;
            result.InterviewerPositionId = item.InterviewerPositionId;
            result.Notes = item.Notes;
            result.Observers = item.Observers;
            result.OnSite = item.OnSite;
            result.Planned = item.Planned;
            result.ProtocolFollowed = item.ProtocolFollowed;
            result.UpdateDate = DateTime.UtcNow;
            result.UpdatedById = userId;

            result.CaseInterviewDocumentationTypes.ForEach(dt => {
                if (!item.CaseInterviewDocumentationTypes.Any(idt => idt.InterviewDocumentationTypeId == dt.InterviewDocumentationTypeId))
                    db.Entry(dt).State = EntityState.Deleted;
                else
                    db.Entry(dt).State = EntityState.Unchanged;
            });

            item.CaseInterviewDocumentationTypes.ForEach(dt => {
                if (!result.CaseInterviewDocumentationTypes.Any(idt => idt.InterviewDocumentationTypeId == dt.InterviewDocumentationTypeId))
                    result.CaseInterviewDocumentationTypes.Add(dt);
            });

            await db.SaveChangesAsync();
        }
    }
}
