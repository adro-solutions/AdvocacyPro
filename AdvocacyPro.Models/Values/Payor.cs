using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvocacyPro.Models.Values
{
    public class Payor : ValueBase
    {
        public static List<Payor> Seed()
        {
            return new List<Payor> { new Payor { Name = "State" },
                    new Payor { Name = "Client" }};
        }
    }
}

