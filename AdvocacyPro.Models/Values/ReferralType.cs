using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Values
{
    public class ReferralType : ValueBase
    {
        public static List<ReferralType> Seed()
        {
            return new List<ReferralType> { new ReferralType { Name = "Delinquent Behavior" },
                    new ReferralType { Name = "Truancy from School" },
                    new ReferralType { Name = "Defiance of School Rules" },
                    new ReferralType { Name = "Non-School Issues" },
                    new ReferralType { Name = "Running Away" },
                    new ReferralType { Name = "Beyond Control" },
                    new ReferralType { Name = "Indecent / Immoral Conduct" },
                    new ReferralType { Name = "Special Issuesr" } };
        }
    }
}
