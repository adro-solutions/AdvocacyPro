using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Values
{
    public class DocumentType : ValueBase
    {
        public static List<DocumentType> Seed()
        {
            return new List<DocumentType> { new DocumentType { Name = "Photos" },
                    new DocumentType { Name = "Medical Release" },
                    new DocumentType { Name = "Consent Form" }};
        }
    }
}
