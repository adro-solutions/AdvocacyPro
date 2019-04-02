using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Values
{
    public class ServiceCategory : ValueBase
    {
        public static List<ServiceCategory> Seed() {
            return new List<ServiceCategory> {new ServiceCategory { Name = "Residential Services" },
                    new ServiceCategory { Name = "Day Services" },
                    new ServiceCategory { Name = "Behavior Services" },
                    new ServiceCategory { Name = "Mental Health Services" },
                    new ServiceCategory { Name = "Employment Services" },
                    new ServiceCategory { Name = "Referal to Outside Agencies / Resources" },
                    new ServiceCategory { Name = "Medical Services" },
                    new ServiceCategory { Name = "School Services" },
                    new ServiceCategory { Name = "Other" } };
        }
    }
}
