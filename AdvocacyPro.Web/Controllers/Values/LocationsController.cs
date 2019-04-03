using AdvocacyPro.Services;
using AdvocacyPro.Services.Values;
using AdvocacyPro.Models.Values;
using AdvocacyPro.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvocacyPro.Web.Controllers.Values
{
    [Route("api/[controller]")]
    public class LocationsController : AuthBaseController
    {
        LocationsLogic logic;
        public LocationsController(LocationsLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public virtual async Task<List<string>> Get(int caseId)
        {
            return await logic.Get(this.OrganizationId);
        }
    }
}
