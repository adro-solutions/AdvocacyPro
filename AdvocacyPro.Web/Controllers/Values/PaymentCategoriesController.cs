using AdvocacyPro.Services.Values;
using AdvocacyPro.Models.Values;
using AdvocacyPro.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace AdvocacyPro.Web.Server.RestAPI.Values
{
    [Route("api/[controller]")]
    public class PaymentCategoriesController : ValueBaseController<PaymentCategoryLogic, PaymentCategory>
    {
        public PaymentCategoriesController(PaymentCategoryLogic logic) : base(logic)
        {
        }
    }
}
