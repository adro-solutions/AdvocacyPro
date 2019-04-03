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
    public class CaseDocumentLogic : CaseChildBaseLogic<CaseDocument>
    {
        public CaseDocumentLogic(DataContext db) : base(db)
        {
        }

        public async override Task<List<CaseDocument>> Get(int caseId, int organizationId)
        {
            return await (from v in db.CaseDocument
                          join c in db.Case on v.CaseId equals c.Id
                          where v.CaseId == caseId
                          && c.OrganizationId == organizationId
                          select new CaseDocument()
                          {
                              Id = v.Id,
                              CaseId = v.CaseId,
                              CreateDate = v.CreateDate,
                              CreatedById = v.CreatedById,
                              DocumentTypeId = v.DocumentTypeId,
                              FileName = v.FileName,
                              UpdateDate = v.UpdateDate,
                              UpdatedById = v.UpdatedById,
                              Notes = v.Notes
                          }).ToListAsync();
        }

        public async override Task<CaseDocument> Get(int id, int caseId, int organizationId)
        {
            var result = await (from v in db.CaseDocument
                                join c in db.Case on v.CaseId equals c.Id
                                where v.Id == id
                                && v.CaseId == caseId
                                && c.OrganizationId == organizationId
                                select new CaseDocument()
                                {
                                    Id = v.Id,
                                    CaseId = v.CaseId,
                                    CreateDate = v.CreateDate,
                                    CreatedById = v.CreatedById,
                                    DocumentTypeId = v.DocumentTypeId,
                                    FileName = v.FileName,
                                    UpdateDate = v.UpdateDate,
                                    UpdatedById = v.UpdatedById,
                                    Notes = v.Notes
                                }).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            return result;
        }

        public async override Task Update(int id, int caseId, int organizationId, int userId, CaseDocument item)
        {
            var result = await (from v in db.CaseDocument
                                join c in db.Case on v.CaseId equals c.Id
                                where v.Id == id
                                && v.CaseId == caseId
                                && c.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            result.DocumentTypeId = item.DocumentTypeId;
            result.UpdatedById = userId;
            result.UpdateDate = DateTime.UtcNow;
            result.Notes = item.Notes;


            await db.SaveChangesAsync();
        }

        public async Task<CaseDocument> Upload(int id, int caseId, int organizationId, int userId, string fileName, byte[] file)
        {
            var result = await (from v in db.CaseDocument
                                join c in db.Case on v.CaseId equals c.Id
                                where v.Id == id
                                && v.CaseId == caseId
                                && c.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            result.FileName = fileName;
            result.File = file;
            result.UpdatedById = userId;
            result.UpdateDate = DateTime.UtcNow;

            await db.SaveChangesAsync();
            return result;
        }

        public async Task<byte[]> Download(int id, int caseId, int organizationId)
        {
            var result = await (from v in db.CaseDocument
                                join c in db.Case on v.CaseId equals c.Id
                                where v.Id == id
                                && v.CaseId == caseId
                                && c.OrganizationId == organizationId
                                select v.File).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            return result;
        }
    }
}
