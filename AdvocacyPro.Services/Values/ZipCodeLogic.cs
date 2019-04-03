using AdvocacyPro.Data;
using AdvocacyPro.Models.Values;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AdvocacyPro.Models.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AdvocacyPro.Services.Values
{
    public class ZipCodeLogic
    {
        protected DataContext db;

        public ZipCodeLogic(DataContext db)
        {
            this.db = db;
        }

        public async Task<ZipCode> Get(string zipCode)
        {
            var result = await (from v in db.ZipCode
                                where v.Code == zipCode
                                select v).FirstOrDefaultAsync();

            return result;
        }
    }
}
