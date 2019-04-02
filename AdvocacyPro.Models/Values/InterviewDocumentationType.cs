using AdvocacyPro.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvocacyPro.Models.Values
{
    public class InterviewDocumentationType :ValueBase
    {
        public static List<InterviewDocumentationType> Seed()
        {
            return new List<InterviewDocumentationType> { new InterviewDocumentationType { Name = "Video" },
                new InterviewDocumentationType { Name = "Audio" },
                new InterviewDocumentationType { Name = "Written" } };
        }
    }
}
