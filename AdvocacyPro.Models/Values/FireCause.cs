using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Models.Values
{
    public class FireCause : ValueBase
    {
        public static List<FireCause> Seed()
        {
            return new List<FireCause> { new FireCause { Name = "Cooking" },
                    new FireCause { Name = "Smoking Materials" },
                    new FireCause { Name = "Open Flames" },
                    new FireCause { Name = "Electrical" },
                    new FireCause { Name = "Heating Equipment" },
                    new FireCause { Name = "Hazardous Products" },
                    new FireCause { Name = "Machinery Industrial" },
                    new FireCause { Name = "Natural" },
                    new FireCause { Name = "Other" },
                    new FireCause { Name = "Intentional" },
                    new FireCause { Name = "Undetermined" }};
        }
    }
}
