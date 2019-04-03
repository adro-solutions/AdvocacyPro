using AdvocacyPro.Services.Values;
using AdvocacyPro.Models.Values;
using AdvocacyPro.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace AdvocacyPro.Web.Server.RestAPI.Values
{
    [Route("api/[controller]")]
    public class InterviewerPositionsController : ValueBaseController<InterviewerPositionLogic, InterviewerPosition>
    {
        public InterviewerPositionsController(InterviewerPositionLogic logic) : base(logic)
        {
        }
    }
}
