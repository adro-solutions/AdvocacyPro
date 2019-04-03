using AdvocacyPro.Services.Base;
using AdvocacyPro.Models.Exceptions;
using AdvocacyPro.Data;
using AdvocacyPro.Models.Values;
using AdvocacyPro.Services.Utility;

namespace AdvocacyPro.Services.Values
{
    public class AgeGroupingLogic : ValueBaseLogic<AgeGrouping>
    {
        public AgeGroupingLogic(DataContext db, ObjectLogic objectLogic) : base(db, objectLogic)
        {
        }
    }
}
