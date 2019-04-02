using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvocacyPro.Models.Values
{
    public class Language : ValueBase
    {
        public static List<Language> Seed()
        {
            return new List<Language> { new Language { Name = "English" },
                new Language { Name = "Spanish" } };
        }
    }
}
