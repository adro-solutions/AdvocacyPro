using AdvocacyPro.Data;
using AdvocacyPro.Models;
using AdvocacyPro.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Services
{
    public class UserLogic
    {
        DataContext db;

        public UserLogic(DataContext db)
        {
            this.db = db;
        }

        public async Task<List<UserData>> GetUsers(int organizationId)
        {
            var members = from member in db.Member
                          where member.OrganizationId == organizationId
                          select new UserData
                          {
                              Id = member.Id,
                              FirstName = member.FirstName,
                              LastName = member.LastName
                          };

            return await members.ToListAsync();
        }

        public async Task<UserData> GetUser(int organizationId, int userId)
        {
            var members = from member in db.Member
                          where member.OrganizationId == organizationId && member.Id == userId
                          select new UserData
                          {
                              Id = member.Id,
                              FirstName = member.FirstName,
                              LastName = member.LastName
                          };

            return await members.FirstOrDefaultAsync();
        }

        public async Task<List<Case>> GetUserCases(int userId)
        {
            var cases = from c in db.Case
                        join s in db.Status on c.StatusId equals s.Id
                        where c.StaffUserId == userId
                        && s.Name == "Open"
                        && c.Archived == false
                        select c;

            return await cases.ToListAsync();
        }

        public async Task<List<Fire>> GetUserFires(int userId)
        {
            var fires = from f in db.Fire
                        join s in db.Status on f.StatusId equals s.Id
                        where f.StaffUserId == userId
                        && s.Name == "Open"
                        && f.Archived == false
                        select f;

            return await fires.ToListAsync();
        }
    }
}
