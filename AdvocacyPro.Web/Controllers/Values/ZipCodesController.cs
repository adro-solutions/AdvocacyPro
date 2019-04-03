using AdvocacyPro.Services.Values;
using AdvocacyPro.Models.Values;
using AdvocacyPro.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Web.Server.RestAPI.Values
{
    [Route("api/[controller]")]
    public class ZipCodesController : AuthBaseController
    {
        ZipCodeLogic logic;
        public ZipCodesController(ZipCodeLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet("{zipCode}")]
        public async Task<ZipCode> Get(string zipCode)
        {
            return await logic.Get(zipCode);
        }
    }
}
