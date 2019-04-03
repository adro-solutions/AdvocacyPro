using AdvocacyPro.Data;
using AdvocacyPro.Services.Base;
using AdvocacyPro.Models;
using AdvocacyPro.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Services
{
    public class FireLogic
    {
        DataContext db;
        public FireLogic(DataContext db)
        {
            this.db = db;
        }

        public async Task<List<Fire>> Get(int organizationId, bool archived)
        {
            return await db.Fire.Where(f => f.OrganizationId == organizationId && f.Archived == archived).ToListAsync();
        }

        public async Task<Fire> Get(int id, int organizationId)
        {
            var result = await (from v in db.Fire
                                where v.Id == id
                                && v.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            return result;
        }

        public async Task<Fire> Create(int organizationId, int userId, Fire item)
        {
            item.OrganizationId = organizationId;
            item.CreatedById = userId;
            item.StatusId = db.Status.First(s => s.Name == "Open").Id;
            db.Fire.Add(item);
            await db.SaveChangesAsync();
            return item;
        }

        public async Task<Fire> Update(int id, int organizationId, int userId, Fire item)
        {
            var result = await (from v in db.Fire
                                where v.Id == id
                                && v.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            result.Archived = item.Archived;
            result.CauseId = item.CauseId;
            result.Disposition = item.Disposition;
            result.ReportDate = item.ReportDate;
            result.Location = item.Location;
            result.LocationTypeId = item.LocationTypeId;
            result.Notes = item.Notes;
            result.OccurrenceDate = item.OccurrenceDate;
            result.StatusId = item.StatusId;
            result.UpdateDate = DateTime.UtcNow;
            result.UpdatedById = userId;
            result.StaffUserId = item.StaffUserId;

            await db.SaveChangesAsync();

            return result;
        }

        public async Task Delete(int id, int organizationId)
        {
            var result = await (from v in db.Fire
                                where v.Id == id
                                && v.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            db.Fire.Remove(result);
            await db.SaveChangesAsync();
        }

        public async Task<int> Count(int organizationId, string status)
        {
            return await (from f in db.Fire
                          join s in db.Status on f.StatusId equals s.Id
                          where f.OrganizationId == organizationId
                          && s.Name == status
                          select f).CountAsync();
        }
    }
}
