using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdvocacyPro.Models;
using AdvocacyPro.Services;
using AdvocacyPro.Web.Controllers.Base;
using AdvocacyPro.Models.Constants;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvocacyPro.Web.Controllers
{
    [Route("api/cases/{caseId}/police"), Authorize(Policy = ProductFeatures.CasePoliceInvolved)]
    public class CasePoliceController : CaseChildBaseController<CasePoliceLogic, CasePolice>
    {
        public CasePoliceController(CasePoliceLogic logic) : base(logic)
        {
        }
    }
}
