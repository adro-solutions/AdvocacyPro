using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdvocacyPro.Models;
using AdvocacyPro.Services;
using AdvocacyPro.Web.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using AdvocacyPro.Models.Constants;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvocacyPro.Web.Controllers
{
    [Route("api/cases/{caseId}/incidents"), Authorize(Policy = ProductFeatures.CaseIncidents)]
    public class CaseIncidentsController : CaseChildBaseController<CaseIncidentLogic, CaseIncident>
    {
        public CaseIncidentsController(CaseIncidentLogic logic) : base(logic)
        {
        }
    }
}
