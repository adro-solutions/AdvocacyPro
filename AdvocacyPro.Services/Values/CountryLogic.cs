using AdvocacyPro.Data;
using AdvocacyPro.Services.Base;
using AdvocacyPro.Services.Utility;
using AdvocacyPro.Models.Values;

namespace AdvocacyPro.Services.Values
{
    public class CountryLogic : ValueBaseLogic<Country>
    {
        public CountryLogic(DataContext db, ObjectLogic objectLogic) : base(db, objectLogic)
        {
           
        }
    }
}
