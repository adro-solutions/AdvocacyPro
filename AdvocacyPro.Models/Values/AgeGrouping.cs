using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Values
{
    public class AgeGrouping : ValueBase
    {
        public static List<AgeGrouping> Seed()
        {
            return new List<AgeGrouping>() {new AgeGrouping { Name = "1-7" },
                    new AgeGrouping { Name = "7-12" },
                    new AgeGrouping { Name = "13-18" },
                    new AgeGrouping { Name = "19-24" },
                    new AgeGrouping { Name = "25-30" },
                    new AgeGrouping { Name = "30-40" },
                    new AgeGrouping { Name = "40+" },
                    new AgeGrouping { Name = "Unknown" } };
        }
    }
}
