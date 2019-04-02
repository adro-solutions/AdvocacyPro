using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Values
{
    public class ContactType : ValueBase
    {
        public static List<ContactType> Seed()
        {
            return new List<ContactType> { new ContactType { Name = "Community Service" },
                    new ContactType { Name = "Individual Counseling" },
                    new ContactType { Name = "Parent Education" },
                    new ContactType { Name = "Group Therapy" },
                    new ContactType { Name = "Crisis Intervention" },
                    new ContactType { Name = "Case Management" },
                    new ContactType { Name = "Positive Youth Development - School" },
                    new ContactType { Name = "Positive Youth Development - Out of School" },
                    new ContactType { Name = "Educational Program" },
                    new ContactType { Name = "Employment Training" },
                    new ContactType { Name = "Referred to Another Agency" },
                    new ContactType { Name = "Family Therapy" },
                    new ContactType { Name = "Other" }};
        }
    }
}
