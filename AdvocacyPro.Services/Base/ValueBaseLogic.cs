using AdvocacyPro.Data;
using AdvocacyPro.Services.Base;
using AdvocacyPro.Services.Utility;
using AdvocacyPro.Models.Base;
using AdvocacyPro.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Services.Base
{
    public abstract class ValueBaseLogic<T> where T:ValueBase
    {
        protected DataContext db;
        protected ObjectLogic vLogic;
        public ValueBaseLogic(DataContext db, ObjectLogic vLogic)
        {
            this.db = db;
            this.vLogic = vLogic;
        }

        public virtual async Task<List<T>> Get()
        {
            return await db.Set<T>().ToListAsync();
        }

        public virtual async Task<T> Get(int id)
        {
            var result = await (from v in db.Set<T>()
                                where v.Id == id
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            return result;
        }

        public virtual async Task<T> Create(T item)
        {
            db.Set<T>().Add(item);
            await db.SaveChangesAsync();
            await vLogic.LogVersion<T>();
            return item;
        }

        public virtual async Task Update(int id, T item)
        {
            var result = await (from v in db.Set<T>()
                                where v.Id == id
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            result.Name = item.Name;
            await db.SaveChangesAsync();
            await vLogic.LogVersion<T>();
        }

        public virtual async Task Delete(int id)
        {
            var result = await (from v in db.Set<T>()
                                where v.Id == id
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            db.Set<T>().Remove(result);
            await db.SaveChangesAsync();
            await vLogic.LogVersion<T>();
        }
    }
}
