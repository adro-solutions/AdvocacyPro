using AdvocacyPro.Data;
using AdvocacyPro.Services.Values;
using AdvocacyPro.Models;
using AdvocacyPro.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Services
{
    public class CaseLogic
    {
        DataContext db;
        public CaseLogic(DataContext db)
        {
            this.db = db;
        }

        public async Task<List<Case>> Get(int organizationId, bool archived)
        {
            return await db.Case.Where(f => f.OrganizationId == organizationId && f.Archived == archived).ToListAsync();
        }

        public async Task<Case> Get(int id, int organizationId)
        {
            var result = await (from v in db.Case
                                where v.Id == id
                                && v.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            return result;
        }

        public async Task<Case> Create(int organizationId, int userId, Case item)
        {
            item.OrganizationId = organizationId;
            item.CreatedById = userId;
            item.StatusId = db.Status.First(s => s.Name == "Open").Id;
            db.Case.Add(item);
            await db.SaveChangesAsync();
            return item;
        }

        public async Task<Case> Update(int id, int organizationId, int userId, Case item)
        {
            var result = await (from v in db.Case
                                where v.Id == id
                                && v.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            result.Address = item.Address;
            result.Age = item.Age;
            result.Archived = item.Archived;
            result.CaseDate = item.CaseDate;
            result.CellPhone = item.CellPhone;
            result.City = item.City;
            result.DOB = item.DOB;
            result.Email = item.Email;
            result.EthnicityId = item.EthnicityId;
            result.FirstName = item.FirstName;
            result.GenderId = item.GenderId;
            result.HomePhone = item.HomePhone;
            result.LastName = item.LastName;
            result.MiddleName = item.MiddleName;
            result.Notes = item.Notes;
            result.RaceId = item.RaceId;
            result.StateId = item.StateId;
            result.UpdateDate = DateTime.UtcNow;
            result.WorkPhone = item.WorkPhone;
            result.ZipCode = item.ZipCode;
            result.UpdatedById = userId;
            result.StatusId = item.StatusId;
            result.StaffUserId = item.StaffUserId;
            
            await db.SaveChangesAsync();

            return result;
        }

        public async Task Delete(int id, int organizationId)
        {
            var result = await (from v in db.Case
                                where v.Id == id
                                && v.OrganizationId == organizationId
                                select v).FirstOrDefaultAsync();

            if (result == null)
                throw new NotFoundException();

            db.Case.Remove(result);
            await db.SaveChangesAsync();
        }

        public async Task<int> Count(int organizationId, string status)
        {
            return await (from c in db.Case
                          join s in db.Status on c.StatusId equals s.Id
                          where c.OrganizationId == organizationId
                          && s.Name == status
                          select c).CountAsync();
        }
    }
}
