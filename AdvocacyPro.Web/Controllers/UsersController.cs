using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvocacyPro.Services;
using Microsoft.AspNetCore.Mvc;
using AdvocacyPro.Web.Controllers.Base;
using AdvocacyPro.Models.DTO;
using AdvocacyPro.Models;
using AdvocacyPro.Services.Auth;
using AdvocacyPro.Models.Constants;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvocacyPro.Web.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : AuthBaseController
    {
        UserLogic logic;
        FeatureLogic fLogic;

        public UsersController(UserLogic logic, FeatureLogic fLogic)
        {
            this.logic = logic;
            this.fLogic = fLogic;
        }

        // GET: api/values
        [HttpGet, Route("Current")]
        public IActionResult Current()
        {
            return Ok(UserData);
        }

        [HttpGet, Route("Current/Features")]
        public IActionResult CurrentFeatures()
        {
            var features = fLogic.GetAll();

            var results = from c in User.Claims
                          join f in features on c.Value equals f.Value
                          where c.Type == ProductFeaturesClaimType.Value
                          select new Feature() { Value = c.Value, Name = features.First(f => f.Value == c.Value).Name };

            return Ok(results);
        }
              
        [HttpGet]
        public async Task<List<UserData>> Get()
        {
            return await logic.GetUsers(this.OrganizationId);
        }

        [HttpGet, Route("{id}")]
        public async Task<UserData> Get(int id)
        {
            return await logic.GetUser(this.OrganizationId, id);
        }

        [HttpGet, Route("{id}/cases")]
        public async Task<List<Case>> GetCases(int id)
        {
            return await logic.GetUserCases(id);
        }

        [HttpGet, Route("{id}/fires")]
        public async Task<List<Fire>> GetFires(int id)
        {
            return await logic.GetUserFires(id);
        }
    }
}
