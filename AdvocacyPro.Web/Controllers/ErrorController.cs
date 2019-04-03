using AdvocacyPro.Models.DTO;
using AdvocacyPro.Web.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvocacyPro.Web.Server.RestAPI
{
    [Route("api/[controller]")]
    public class ErrorController : AuthBaseController
    {
        ILogger logger;
        public ErrorController(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<ErrorController>();
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Post([FromBody]ClientError error)
        {
            logger.LogError(error.error);
            return Ok();
        }
    }
}
