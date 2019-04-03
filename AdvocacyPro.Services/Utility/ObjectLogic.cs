using AdvocacyPro.Data;
using AdvocacyPro.Models.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvocacyPro.Services.Utility
{
    public class ObjectLogic
    {
        protected DataContext db;
        public ObjectLogic(DataContext db)
        {
            this.db = db;
        }

        public async Task LogVersion<T>()
        {
            var objectVersion = await db.ObjectVersion.FindAsync(typeof(T).ToString());

            if (objectVersion != null)
                objectVersion.Version++;
            else
            {
                objectVersion = new ObjectVersion(typeof(T).ToString());
                await db.ObjectVersion.AddAsync(objectVersion);
            }
            
            await db.SaveChangesAsync();
        }

        public async Task<List<ObjectVersion>> GetVersions()
        {
            return await db.ObjectVersion.ToListAsync();
        }

        public Type GetLogicType(string name)
        {
            Type type = Type.GetType($"AdvocacyPro.Logic.{name}Logic");

            if (type == null)
                type = Type.GetType($"AdvocacyPro.Logic.Values.{name}Logic");

            return type;
        }
    }
}
