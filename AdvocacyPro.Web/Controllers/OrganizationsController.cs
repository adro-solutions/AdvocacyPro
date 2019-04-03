using AdvocacyPro.Services.Values;
using AdvocacyPro.Models.Auth;
using AdvocacyPro.Models.Constants;
using AdvocacyPro.Models.DTO;
using AdvocacyPro.Models.Result;
using AdvocacyPro.Models.Values;
using AdvocacyPro.Web.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvocacyPro.Web.Controllers
{
    [Route("api/[controller]")]
    public class OrganizationsController : AuthBaseController
    {

        OrganizationLogic logic;
        public OrganizationsController(OrganizationLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet("Current")]
        public async Task<Organization> GetCurrent()
        {
            return await logic.Get(this.OrganizationId);
        }

        [HttpGet, Authorize(Policy = ProductFeatures.AdministerOrganizations)]
        public async Task<List<Organization>> Get()
        {
            return await logic.Get();
        }

        [HttpGet("{id}"), Authorize(Policy = ProductFeatures.AdministerOrganizations)]
        public async Task<Organization> Get(int id)
        {
            return await logic.Get(id);
        }

        [HttpPost, Authorize(Policy = ProductFeatures.AdministerOrganizations)]
        public async Task<IActionResult> Post([FromBody]Organization value)
        {
            if (ModelState.IsValid)
            {
                return Ok(await logic.Create(value));
            }
            else
                return BadRequest(ModelState);

        }

        [HttpPut("{id}"), Authorize(Policy = ProductFeatures.AdministerOrganizations)]
        public async Task<IActionResult> Put(int id, [FromBody]Organization value)
        {
            if (ModelState.IsValid)
            {
                await logic.Update(id, value);
                return Ok();
            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete("{id}"), Authorize(Policy = ProductFeatures.AdministerOrganizations)]
        public async Task Delete(int id)
        {
            await logic.Delete(id);
        }

        [HttpPost("{id}/logo"), Authorize(Policy = ProductFeatures.AdministerOrganizations)]
        public async Task<IActionResult> PostLogo(int id)
        {
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files.First();
                if (file.Length > .5 * 1024 * 1024)
                    return BadRequest("File size greater than 512KB.");

                var s = new MemoryStream();
                await file.CopyToAsync(s);
                var fileBytes = s.ToArray();
                return Ok(await logic.Upload(id, fileBytes));
            }
            else
                return BadRequest();
        }

        [HttpGet("{id}/users"), Authorize(Policy = ProductFeatures.AdministerMembers)]
        public async Task<IActionResult> GetUsers(int id)
        {
            if (id == this.OrganizationId || User.HasClaim(ProductFeaturesClaimType.Value, ProductFeatures.AdministerOrganizations))
                return Ok(await logic.GetUsers(id));

            return Forbid();
        }

        [HttpGet("{id}/users/{userId}"), Authorize(Policy = ProductFeatures.AdministerMembers)]
        public async Task<IActionResult> GetUser(int id, int userId)
        {
            if (id == this.OrganizationId || User.HasClaim(ProductFeaturesClaimType.Value, ProductFeatures.AdministerOrganizations))
                return Ok(await logic.GetUser(id, userId));

            return Forbid();
        }

        [HttpPost("{id}/users"), Authorize(Policy = ProductFeatures.AdministerMembers)]
        public async Task<IActionResult> CreateUser(int id, [FromBody] MemberData member)
        {

            if (id == this.OrganizationId || User.HasClaim(ProductFeaturesClaimType.Value, ProductFeatures.AdministerOrganizations))
            {

                CreateUserResult result = await logic.CreateUser(id, member);

                if (result.Success)
                    return Ok(result.CreatedUser);

                Response.Headers.Add("X-ExceptionMessage", result.ErrorDescription);
                return BadRequest();

            }

            return Forbid();
        }

        [HttpPut("{id}/users/{userId}"), Authorize(Policy = ProductFeatures.AdministerMembers)]
        public async Task<IActionResult> UpdateUser(int id, int userId, [FromBody] MemberData member)
        {
            if (id == this.OrganizationId || User.HasClaim(ProductFeaturesClaimType.Value, ProductFeatures.AdministerOrganizations))
                return Ok(await logic.UpdateUser(id, userId, member));

            return Forbid();
        }

        [HttpDelete("{id}/users/{userId}"), Authorize(Policy = ProductFeatures.AdministerOrganizations)]
        public async Task<IActionResult> DeleteUser(int id, int userId)
        {
            if (id == this.OrganizationId || User.HasClaim(ProductFeaturesClaimType.Value, ProductFeatures.AdministerOrganizations))
            {
                await logic.DeleteUser(id, userId);
                return Ok();
            }

            return Forbid();
        }

        [HttpGet("{id}/users/{userId}/features"), Authorize(Policy = ProductFeatures.AdministerMembers)]
        public async Task<IActionResult> GetUserFeatures(int id, int userId)
        {
            if (id == this.OrganizationId || User.HasClaim(ProductFeaturesClaimType.Value, ProductFeatures.AdministerOrganizations))
                return Ok(await logic.GetUserFeatures(id, userId));

            return Forbid();
        }

        [HttpPost("{id}/users/{userId}/features"), Authorize(Policy = ProductFeatures.AdministerMembers)]
        public async Task<IActionResult> UpdateUserFeatures(int id, int userId, [FromBody] List<Feature> features)
        {
            if (id == this.OrganizationId || User.HasClaim(ProductFeaturesClaimType.Value, ProductFeatures.AdministerOrganizations))
            {
                await logic.UpdateUserFeatures(id, userId, features);
                return Ok();
            }

            return Forbid();
        }


        [HttpGet("{id}/features"), Authorize(Policy = ProductFeatures.AdministerOrganizations)]
        public async Task<IActionResult> GetFeatures(int id)
        { 
            if (id == this.OrganizationId || User.HasClaim(ProductFeaturesClaimType.Value, ProductFeatures.AdministerOrganizations))
            {
                return Ok(await logic.GetFeatures(id));
            }

            return Forbid();
        }

        [HttpPost("{id}/features"), Authorize(Policy = ProductFeatures.AdministerOrganizations)]
        public async Task<IActionResult> UpdateFeatures(int id, [FromBody] List<OrganizationFeature> features)
        {
            await logic.UpdateFeatures(id, features);
            return Ok();
        }
    }
}
