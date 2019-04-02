using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvocacyPro.Models.Values
{
    public class InterviewerPosition : ValueBase
    {
        public static List<InterviewerPosition> Seed()
        {
            return new List<InterviewerPosition> { new InterviewerPosition { Name = "Law Enforcement" },
                new InterviewerPosition { Name = "CPS Employee" },
                new InterviewerPosition { Name = "School Counselor" },
                new InterviewerPosition { Name = "Trained Investigative Interviewer" },
                new InterviewerPosition { Name = "Health Care Provider" },
                new InterviewerPosition { Name = "Other" }};
        }
    }
}
