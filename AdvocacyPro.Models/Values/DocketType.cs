using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvocacyPro.Models.Values
{
    public class DocketType : ValueBase
    {
        public static List<DocketType> Seed()
        {
            return new List<DocketType> { new DocketType { Name = "Pretrial" },
                new DocketType { Name = "Motion" },
                new DocketType { Name = "Trial" },
                new DocketType { Name = "Sentancing" },
                new DocketType { Name = "Regular Docket" }};
        }
    }
}
