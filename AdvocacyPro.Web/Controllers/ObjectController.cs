using Microsoft.AspNetCore.Mvc;
using System;
using AdvocacyPro.Models;
using Microsoft.AspNetCore.Authorization;
using AdvocacyPro.Web.Controllers.Base;
using AdvocacyPro.Services.Utility;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvocacyPro.Web.Controllers
{
    [Route("api/[controller]")]
    public class ObjectController : AuthBaseController
    {
        ObjectLogic vLogic;
        public ObjectController(ObjectLogic vLogic)
        {
            this.vLogic = vLogic;
        }

        [HttpGet("{type}/ValidationInfo"), AllowAnonymous]
        public IActionResult Get(string type)
        {            
            return Ok(Typings.GetValidationInfo(type));
        }

        [HttpGet("Versions")]
        public async Task<IActionResult> Get()
        {
            return Ok(await vLogic.GetVersions());
        }

    }
}
