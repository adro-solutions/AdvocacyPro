using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvocacyPro.Models.Values
{
    public class ApplicationStatus : ValueBase
    {
        public static List<ApplicationStatus> Seed()
        {
            return new List<ApplicationStatus> { new ApplicationStatus { Name = "TCVC - Application" },
                    new ApplicationStatus { Name = "TCVC - Submitted" },
                    new ApplicationStatus { Name = "TCVC - Denied" },
                    new ApplicationStatus { Name = "TCVC - Emergency" },
                    new ApplicationStatus { Name = "TCVC - Approved 50%" } };
        }
    }
}
