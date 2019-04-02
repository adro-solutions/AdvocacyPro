using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Values
{
    public class LocationType : ValueBase
    {
        public static List<LocationType> Seed()
        {
            return new List<LocationType> { new LocationType { Name = "On - Campus Property" },
                    new LocationType { Name = "On - Campus Student Housing Facilities" },
                    new LocationType { Name = "Non - Campus Property" },
                    new LocationType { Name = "Public Property" } };
        }
    }
}
