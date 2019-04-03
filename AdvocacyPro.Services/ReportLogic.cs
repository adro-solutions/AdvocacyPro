using AdvocacyPro.Data;
using AdvocacyPro.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AdvocacyPro.Models;

namespace AdvocacyPro.Services
{
    public class ReportLogic
    {
        DataContext db;
        public ReportLogic(DataContext db)
        {
            this.db = db;
        }

        public async Task<List<CaseIncident>> GetCrimeReportData(DateTime startDate, DateTime endDate, int organizationId)
        {
            return await (from i in db.CaseIncident
                          join c in db.Case on i.CaseId equals c.Id
                          where c.OrganizationId == organizationId
                          && i.OccurrenceDate >= startDate.Date
                          && i.OccurrenceDate < endDate.AddDays(1).Date
                          select i).ToListAsync();
        }

        public async Task<List<Fire>> GetFireReportData(DateTime startDate, DateTime endDate, int organizationId)
        {
            return await (from f in db.Fire
                          where f.OrganizationId == organizationId
                          && f.OccurrenceDate >= startDate.Date
                          && f.OccurrenceDate < endDate.AddDays(1).Date
                          select f).ToListAsync();
        }

        public async Task<List<Case>> GetCaseReportData(DateTime startDate, DateTime endDate, int organizationId)
        {
            return await (from c in db.Case 
                          where c.OrganizationId == organizationId
                          && c.CaseDate >= startDate.Date
                          && c.CaseDate < endDate.AddDays(1).Date
                          select c).ToListAsync();
        }

        public async Task<List<CaseService>> GetServiceReportData(DateTime startDate, DateTime endDate, int organizationId)
        {
            return await (from i in db.CaseService
                          join c in db.Case on i.CaseId equals c.Id
                          where c.OrganizationId == organizationId
                          && i.CreateDate >= startDate.Date
                          && i.CreateDate < endDate.AddDays(1).Date
                          select i).ToListAsync();
        }

        public async Task<List<CaseVictimization>> GetVictimizationReportData(DateTime startDate, DateTime endDate, int organizationId)
        {
            return await (from i in db.CaseVictimization
                          join c in db.Case on i.CaseId equals c.Id
                          where c.OrganizationId == organizationId
                          && i.CreateDate >= startDate.Date
                          && i.CreateDate < endDate.AddDays(1).Date
                          select i).ToListAsync();
        }

    }
}
