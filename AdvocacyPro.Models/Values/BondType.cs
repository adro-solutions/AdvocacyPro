using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvocacyPro.Models.Values
{
    public class BondType : ValueBase
    {
        public static List<BondType> Seed ()
        {
            return new List<BondType> { new BondType { Name = "Professional Surity" },
                new BondType { Name = "Non Surity" },
                new BondType { Name = "Other" }};
        }
    }
}
