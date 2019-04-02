using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Values
{
    public class Gender : ValueBase
    {
        public static List<Gender> Seed()
        {
            return new List<Gender> { new Gender { Name = "Male" },
                    new Gender { Name = "Female" },
                    new Gender { Name = "Unknown" } };
        }
    }
}
