using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Values
{
    public class ServicePopulation : ValueBase
    {
        public static List<ServicePopulation> Seed()
        {
            return new List<ServicePopulation> { new ServicePopulation { Name = "General" } };
        }
    }
}
