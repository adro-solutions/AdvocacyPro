using AdvocacyPro.Services;
using AdvocacyPro.Services.Values;
using AdvocacyPro.Models.Values;
using AdvocacyPro.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvocacyPro.Web.Controllers.Values
{
    [Route("api/[controller]")]
    public class ServicePopulationsController : ValueBaseController<ServicePopulationLogic, ServicePopulation>
    {
        public ServicePopulationsController(ServicePopulationLogic logic) : base(logic)
        {
        }
    }
}
