using AdvocacyPro.Services.Base;
using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Base;
using AdvocacyPro.Models.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvocacyPro.Web.Controllers.Base
{
    [Route("api/[controller]")]
    public abstract class ValueBaseController<TLogic, TModel> : AuthBaseController 
        where TLogic: ValueBaseLogic<TModel>
        where TModel: ValueBase
    {
        protected TLogic logic;

        public ValueBaseController(TLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public virtual async Task<List<TModel>> Get()
        {
            return await logic.Get();
        }

        [HttpGet("{id}")]
        public virtual async Task<TModel> Get(int id)
        {
            return await logic.Get(id);
        }

        [HttpPost, Authorize(Policy = ProductFeatures.AdministerValues)]
        public virtual async Task<IActionResult> Post([FromBody]TModel value)
        {
            if (ModelState.IsValid)
            {
                return Ok(await logic.Create(value));
            }
            else
                return BadRequest(ModelState);

        }

        [HttpPut("{id}"), Authorize(Policy = ProductFeatures.AdministerValues)]
        public virtual async Task<IActionResult> Put(int id, [FromBody]TModel value)
        {
            if (ModelState.IsValid)
            {
                await logic.Update(id, value);
                return Ok();
            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete("{id}"), Authorize(Policy = ProductFeatures.AdministerValues)]
        public virtual async Task Delete(int id)
        {
            await logic.Delete(id);
        }
    }
}
