using AdvocacyPro.Data;
using AdvocacyPro.Services.Base;
using AdvocacyPro.Services.Utility;
using AdvocacyPro.Models.Exceptions;
using AdvocacyPro.Models.Values;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Services.Values
{
    public class ServiceProgramLogic : ValueBaseLogic<ServiceProgram>
    {

        ObjectLogic objectLogic;
        public ServiceProgramLogic(DataContext db, ObjectLogic objectLogic) : base(db, objectLogic)
        {
            this.objectLogic = objectLogic;
        }

        public override async Task Update(int id, ServiceProgram item)
        {
            var result = await (from v in db.ServiceProgram
                                where v.Id == item.Id
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            result.Name = item.Name;
            result.CategoryId = item.CategoryId;
            
            await db.SaveChangesAsync();
            await objectLogic.LogVersion<ServiceProgram>();
        }
    }
}
