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
    [Route("api/cases/{caseId}/emergencycontacts"), Authorize(Policy = ProductFeatures.CaseEmergencyContacts)]
    public class CaseEmergencyContactsController : CaseChildBaseController<CaseEmergencyContactLogic, CaseEmergencyContact>
    {
        public CaseEmergencyContactsController(CaseEmergencyContactLogic logic) : base(logic)
        {
        }
    }
}
