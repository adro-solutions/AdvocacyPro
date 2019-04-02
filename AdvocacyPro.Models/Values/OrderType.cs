using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvocacyPro.Models.Values
{
    public class OrderType : ValueBase
    {
        public static List<OrderType> Seed()
        {
            return new List<OrderType> { new OrderType { Name = "Temporary Protective Order" },
                new OrderType { Name = "Ex Parte" },
                new OrderType { Name = "Protective Order" } };
        }
    }
}
