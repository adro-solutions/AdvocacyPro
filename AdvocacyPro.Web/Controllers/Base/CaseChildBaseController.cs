using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdvocacyPro.Services.Base;
using AdvocacyPro.Models.Base;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvocacyPro.Web.Controllers.Base
{
    public abstract class CaseChildBaseController<TLogic, TModel> : AuthBaseController
        where TLogic:CaseChildBaseLogic<TModel>
        where TModel: class,ICaseChild
    {
        protected TLogic logic;

        public CaseChildBaseController(TLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public virtual async Task<List<TModel>> Get(int caseId)
        {
            return await logic.Get(caseId, this.OrganizationId);
        }

        [HttpGet("{id}")]
        public virtual async Task<TModel> Get(int id, int caseId)
        {
            return await logic.Get(id, caseId, this.OrganizationId);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post(int caseId, [FromBody]TModel value)
        {
            if (ModelState.IsValid)
            {
                return Ok(await logic.Create(caseId, this.OrganizationId, this.UserId, value));
            }
            else
                return BadRequest(ModelState);

        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(int id, int caseId, [FromBody]TModel value)
        {
            if (ModelState.IsValid)
            {
                await logic.Update(id, caseId, this.OrganizationId, this.UserId, value);
                return Ok(await logic.Get(id, caseId, this.OrganizationId));
            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public virtual async Task Delete(int id, int caseId)
        {
            await logic.Delete(id, caseId, this.OrganizationId);
        }
    }
}
