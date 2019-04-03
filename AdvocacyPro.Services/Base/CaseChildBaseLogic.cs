using AdvocacyPro.Data;
using AdvocacyPro.Models.Base;
using AdvocacyPro.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Services.Base
{
    public abstract class CaseChildBaseLogic<T> where T : class, ICaseChild
    {
        protected DataContext db;
        public CaseChildBaseLogic(DataContext db)
        {
            this.db = db;
        }

        public async virtual Task<List<T>> Get(int caseId, int organizationId)
        {
            return await (from v in db.Set<T>()
                          join c in db.Case on v.CaseId equals c.Id
                          where v.CaseId == caseId
                          && c.OrganizationId == organizationId
                          select v).ToListAsync();
        }

        public async virtual Task<T> Get(int id, int caseId, int organizationId)
        {
            var result = await (from v in db.Set<T>()
                                join c in db.Case on v.CaseId equals c.Id
                                where v.Id == id
                                && v.CaseId == caseId
                                && c.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            return result;
        }

        public async Task<T> Create(int caseId, int organizationId, int userId, T item)
        {
            var result = await (from c in db.Case
                                where c.Id == caseId
                                && c.OrganizationId == organizationId
                                select c).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            item.CaseId = caseId;
            item.CreatedById = userId;
            db.Set<T>().Add(item);
            await db.SaveChangesAsync();
            return item;
        }

        public abstract Task Update(int id, int caseId, int organizationId, int userId, T item);
        
        public async Task Delete(int id, int caseId, int organizationId)
        {
            var result = await (from v in db.Set<T>()
                                join c in db.Case on v.CaseId equals c.Id
                                where v.Id == id
                                && v.CaseId == caseId
                                && c.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            db.Set<T>().Remove(result);
            await db.SaveChangesAsync();
        }
    }
}
