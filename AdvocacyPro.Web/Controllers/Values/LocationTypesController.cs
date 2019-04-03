using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdvocacyPro.Models.Values;
using AdvocacyPro.Services;
using AdvocacyPro.Web.Controllers.Base;
using AdvocacyPro.Services.Values;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvocacyPro.Web.Controllers.Values
{
    [Route("api/[controller]")]
    public class LocationTypesController : ValueBaseController<LocationTypeLogic, LocationType>
    {
        public LocationTypesController(LocationTypeLogic logic) : base(logic)
        {
        }
    }
}
