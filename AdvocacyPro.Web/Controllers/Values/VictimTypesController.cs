using AdvocacyPro.Services.Values;
using AdvocacyPro.Models.Values;
using AdvocacyPro.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace AdvocacyPro.Web.Server.RestAPI.Values
{
    [Route("api/[controller]")]
    public class VictimTypesController : ValueBaseController<VictimTypeLogic, VictimType>
    {
        public VictimTypesController(VictimTypeLogic logic) : base(logic)
        {
        }
    }
}
