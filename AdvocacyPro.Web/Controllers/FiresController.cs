using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdvocacyPro.Web.Controllers.Base;
using AdvocacyPro.Services;
using AdvocacyPro.Models;
using Microsoft.AspNetCore.Authorization;
using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Constants;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvocacyPro.Web.Controllers
{
    [Route("api/[controller]"), Authorize(Policy = ProductFeatures.Fires)]
    public class FiresController : AuthBaseController
    {
        FireLogic logic;
        public FiresController(FireLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public async Task<List<Fire>> Get()
        {
            return await logic.Get(this.OrganizationId, false);
        }

        [HttpGet("Archived")]
        public async Task<List<Fire>> GetArchived()
        {
            return await logic.Get(this.OrganizationId, true);
        }

        [HttpGet("{id}")]
        public async Task<Fire> Get(int id)
        {
            return await logic.Get(id, this.OrganizationId);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Fire value)
        {
            if (ModelState.IsValid)
            {
                return Ok(await logic.Create(this.OrganizationId, this.UserId, value));
            }
            else
                return BadRequest(ModelState);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Fire value)
        {
            if (ModelState.IsValid)
            {
                return Ok(await logic.Update(id, this.OrganizationId, this.UserId, value));
            }
            else
                return BadRequest(ModelState);
        }

        [HttpGet("Count/{status}")]
        public async Task<int> GetCount(string status)
        {
            return await logic.Count(this.OrganizationId, status);
        }
    }
}
