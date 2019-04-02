using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvocacyPro.Models.Values
{
    public class OrderStatus : ValueBase
    {
        public static List<OrderStatus> Seed()
        {
            return new List<OrderStatus> { new OrderStatus { Name = "Approved" },
                new OrderStatus { Name = "Pending" },
                new OrderStatus { Name = "Denied" } };
        }
    }
}
