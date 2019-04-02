using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvocacyPro.Models.Values
{
    public class LetterType : ValueBase
    {
        public static List<LetterType> Seed()
        {
            return new List<LetterType> { new LetterType { Name = "Notification" },
                new LetterType { Name = "Followup" },
                new LetterType { Name = "Compensation Program" } };
        }
    }
}
