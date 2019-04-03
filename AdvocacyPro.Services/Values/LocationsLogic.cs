using AdvocacyPro.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocacyPro.Services.Values
{
    public class LocationsLogic
    {
        DataContext db;
        public LocationsLogic(DataContext db)
        {
            this.db = db;
        }

        public async Task<List<String>> Get(int organizationId)
        {
            var res = (from d in db.Fire
                       where d.OrganizationId == organizationId
                       select d.Location).Union(from v in db.CaseIncident
                                                join c in db.Case on v.CaseId equals c.Id
                                                where c.OrganizationId == organizationId
                                                select v.Location).Distinct().ToListAsync();

            return await res;
        }
    }
}
