﻿using Microsoft.AspNetCore.Mvc;
using AdvocacyPro.Models;
using AdvocacyPro.Services;
using AdvocacyPro.Web.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using AdvocacyPro.Models.Constants;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvocacyPro.Web.Server.RestAPI
{
    [Route("api/cases/{caseId}/payments"), Authorize(Policy = ProductFeatures.CasePayments)]
    public class CasePaymentsController : CaseChildBaseController<CasePaymentLogic, CasePayment>
    {
        public CasePaymentsController(CasePaymentLogic logic) : base(logic)
        {
        }
    }
}
