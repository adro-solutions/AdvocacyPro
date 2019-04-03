using AdvocacyPro.Services;
using AdvocacyPro.Models;
using AdvocacyPro.Models.Constants;
using AdvocacyPro.Web.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvocacyPro.Web.Server.RestAPI
{
    [Route("api/[controller]")]
    public class ReportsController : AuthBaseController
    {
        ReportLogic logic;
        public ReportsController(ReportLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet("crimedata"), Authorize(Policy = ProductFeatures.ReportsCrime)]
        public async Task<List<CaseIncident>> GetCrimeData(DateTime startDate, DateTime endDate)
        {
            return await logic.GetCrimeReportData(startDate, endDate, this.OrganizationId);
        }

        [HttpGet("firedata"), Authorize(Policy = ProductFeatures.ReportsFire)]
        public async Task<List<Fire>> GetFireData(DateTime startDate, DateTime endDate)
        {
            return await logic.GetFireReportData(startDate, endDate, this.OrganizationId);
        }

        [HttpGet("casedata"), Authorize(Policy = ProductFeatures.ReportsCase)]
        public async Task<List<Case>> GetCaseData(DateTime startDate, DateTime endDate)
        {
            return await logic.GetCaseReportData(startDate, endDate, this.OrganizationId);
        }

        [HttpGet("servicedata"), Authorize(Policy = ProductFeatures.ReportsCase)]
        public async Task<List<CaseService>> GetServiceData(DateTime startDate, DateTime endDate)
        {
            return await logic.GetServiceReportData(startDate, endDate, this.OrganizationId);
        }

        [HttpGet("victimizationdata"), Authorize(Policy = ProductFeatures.ReportsCase)]
        public async Task<List<CaseVictimization>> GetVictimizationData(DateTime startDate, DateTime endDate)
        {
            return await logic.GetVictimizationReportData(startDate, endDate, this.OrganizationId);
        }
    }
}
