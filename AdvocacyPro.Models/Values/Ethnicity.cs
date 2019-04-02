using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Values
{
    public class Ethnicity : ValueBase
    {
        public static List<Ethnicity> Seed()
        {
            return new List<Ethnicity> { new Ethnicity { Name = "White Non Hispanic" },
                    new Ethnicity { Name = "Black Non Hispanic" },
                    new Ethnicity { Name = "Hispanic" },
                    new Ethnicity { Name = "Alaskan Native" },
                    new Ethnicity { Name = "Asian & Pacific Isl." },
                    new Ethnicity { Name = "Native American" },
                    new Ethnicity { Name = "Unknown" },
                    new Ethnicity { Name = "Multiracial" } };
        }
    }
}
