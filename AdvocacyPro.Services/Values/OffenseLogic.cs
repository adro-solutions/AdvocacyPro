using AdvocacyPro.Data;
using AdvocacyPro.Services.Base;
using AdvocacyPro.Services.Utility;
using AdvocacyPro.Models.Exceptions;
using AdvocacyPro.Models.Values;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Services.Values
{
    public class OffenseLogic : ValueBaseLogic<Offense>
    {
        ObjectLogic objectLogic;
        public OffenseLogic(DataContext db, ObjectLogic objectLogic) : base(db, objectLogic)
        {
            this.objectLogic = objectLogic;
        }
        
        public override async Task Update(int id, Offense item)
        {
            var result = await (from v in db.Offense
                                where v.Id == item.Id
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            result.Name = item.Name;
            result.TypeId = item.TypeId;
            result.CleryReport = item.CleryReport;

            await db.SaveChangesAsync();
            await objectLogic.LogVersion<Offense>();
        }
    }
}
