using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Values
{
    public class OrganizationType : ValueBase
    {
        public static List<OrganizationType> Seed()
        {
            return new List<OrganizationType> {
                new OrganizationType { Name = "Admin" },
                new OrganizationType { Name = "Non Profit" },
                new OrganizationType { Name = "Medical" },
                new OrganizationType { Name = "Police" },
                new OrganizationType { Name = "State Government" },
                new OrganizationType { Name = "Local Government" },
                new OrganizationType { Name = "Clinical" },
                new OrganizationType { Name = "CBO" },
                new OrganizationType { Name = "Higher Education" }
            };
        }
    }
}
