using AdvocacyPro.Data;
using AdvocacyPro.Services.Base;
using AdvocacyPro.Services.Utility;
using AdvocacyPro.Models.Values;

namespace AdvocacyPro.Services.Values
{
    public class InterviewDocumentationTypeLogic : ValueBaseLogic<InterviewDocumentationType>
    {
        public InterviewDocumentationTypeLogic(DataContext db, ObjectLogic objectLogic) : base(db, objectLogic)
        {
        }
    }
}
