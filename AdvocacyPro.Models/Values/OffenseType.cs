using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Values
{
    public class OffenseType : ValueBase
    {
        public static List<OffenseType> Seed()
        {
            return new List<OffenseType> { new OffenseType { Name = "Criminal Offenses" },
                    new OffenseType { Name = "Hate Crimes" },
                    new OffenseType { Name = "Arrests and Referrals" },
                    new OffenseType { Name = "Other" } };
        }
    }
}
