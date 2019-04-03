using AdvocacyPro.Services;
using AdvocacyPro.Models;
using AdvocacyPro.Models.Constants;
using AdvocacyPro.Web.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvocacyPro.Web.Controllers
{
    [Route("api/cases/{caseId}/contacts"), Authorize(Policy = ProductFeatures.CaseContactLog)]
    public class CaseContactsController : CaseChildBaseController<CaseContactLogic, CaseContact>
    {
        public CaseContactsController(CaseContactLogic logic) : base(logic)
        {
        }
    }
}
