using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdvocacyPro.Services;
using AdvocacyPro.Web.Controllers.Base;
using AdvocacyPro.Models;
using Microsoft.AspNetCore.Authorization;
using AdvocacyPro.Models.Constants;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvocacyPro.Web.Controllers
{
    [Route("api/[controller]"), Authorize(Policy = ProductFeatures.Cases)]
    public class CasesController : AuthBaseController
    {
        CaseLogic logic;
        public CasesController(CaseLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public async Task<List<Case>> Get()
        {
            return await logic.Get(this.OrganizationId, false);
        }

        [HttpGet("Archived")]
        public async Task<List<Case>> GetArchived()
        {
            return await logic.Get(this.OrganizationId, true);
        }

        [HttpGet("{id}")]
        public async Task<Case> Get(int id)
        {
            return await logic.Get(id, this.OrganizationId);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Case value)
        {
            if (ModelState.IsValid)
            {
                return Ok(await logic.Create(this.OrganizationId, this.UserId, value));
            }
            else
                return BadRequest(ModelState);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Case value)
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
