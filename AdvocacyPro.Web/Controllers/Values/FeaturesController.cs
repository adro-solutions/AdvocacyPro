using AdvocacyPro.Services.Auth;
using AdvocacyPro.Models.Constants;
using AdvocacyPro.Models.DTO;
using AdvocacyPro.Web.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AdvocacyPro.Web.Server.RestAPI.Values
{
    [Route("api/[controller]"), Authorize(Policy = ProductFeatures.AdministerOrganizations)]
    public class FeaturesController : AuthBaseController
    {
        FeatureLogic logic;
        public FeaturesController(FeatureLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public virtual List<Feature> Get()
        {
            return logic.GetAll();
        }
    }
}
