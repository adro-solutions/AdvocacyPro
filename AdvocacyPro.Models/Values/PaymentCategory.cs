using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvocacyPro.Models.Values
{
    public class PaymentCategory : ValueBase
    {
        public static List<PaymentCategory> Seed()
        {
            return new List<PaymentCategory> { new PaymentCategory { Name = "Voca Allocation" },
                    new PaymentCategory { Name = "Reimbursement Request" },
                    new PaymentCategory { Name = "Reimbursement Payment" },
                    new PaymentCategory { Name = "Civil Payment Recoupment" }};
        }
    }
}
