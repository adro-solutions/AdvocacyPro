using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Values
{
    public class Race: ValueBase
    {
        [Required, MaxLength(2)]
        public string Code { get; set; }

        public static List<Race> Seed()
        {
            return new List<Race> {  new Race { Name = "Asian Indian", Code = "AA" },
                    new Race { Name = "Cambodian", Code = "AB" },
                    new Race { Name = "Chinese", Code = "AC" },
                    new Race { Name = "Filipino", Code = "AD" },
                    new Race { Name = "Guamanian", Code = "AE" },
                    new Race { Name = "Hawaiian", Code = "AF" },
                    new Race { Name = "Japanese", Code = "AG" },
                    new Race { Name = "Korean", Code = "AH" },
                    new Race { Name = "Samoan", Code = "AJ" },
                    new Race { Name = "Vietnamese", Code = "AK" },
                    new Race { Name = "Other Pacific Islander", Code = "AL" },
                    new Race { Name = "Other Asian", Code = "AO" },
                    new Race { Name = "Black", Code = "BL" },
                    new Race { Name = "Hispanic or Latino", Code = "HI" },
                    new Race { Name = "Laotian", Code = "IA" },
                    new Race { Name = "American Indian / Alaskan Native", Code = "NA" },
                    new Race { Name = "Unknown", Code = "UN" },
                    new Race { Name = "White", Code = "WH" }};
        }
    }
}
