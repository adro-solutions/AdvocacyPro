using AdvocacyPro.Services.Base;
using AdvocacyPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvocacyPro.Data;
using AdvocacyPro.Models.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AdvocacyPro.Services
{
    public class CaseIncidentLogic : CaseChildBaseLogic<CaseIncident>
    {
        public CaseIncidentLogic(DataContext db) : base(db)
        {
        }

        public async override Task Update(int id, int caseId, int organizationId, int userId, CaseIncident item)
        {
            var result = await (from v in db.CaseIncident
                                join c in db.Case on v.CaseId equals c.Id
                                where v.Id == id
                                && v.CaseId == caseId
                                && c.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            result.Disposition = item.Disposition;
            result.Location = item.Location;
            result.LocationTypeId = item.LocationTypeId;
            result.Notes = item.Notes;
            result.OccurrenceDate = item.OccurrenceDate;
            result.OffenseId = item.OffenseId;
            result.ReportDate = item.ReportDate;
            result.StaffUserId = item.StaffUserId;
            result.StatusId = item.StatusId;
            result.UpdateDate = DateTime.UtcNow;
            result.UpdatedById = userId;


            await db.SaveChangesAsync();
        }
    }
}
