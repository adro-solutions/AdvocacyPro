using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Values
{
    public class Status : ValueBase
    {
        public static List<Status> Seed()
        {
            return new List<Status> { new Status { Name = "Open" },
                    new Status { Name = "Closed" } };
        }
    }
}
