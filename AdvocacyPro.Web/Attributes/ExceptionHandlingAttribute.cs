using AdvocacyPro.Models.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Text;

namespace AdvocacyPro.Web.Server.Attributes
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        ILogger logger;

        public ExceptionHandlingAttribute(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<ExceptionHandlingAttribute>();
        }

        public override void OnException(ExceptionContext context)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(context.Exception.ToString());

            var curExc = context.Exception.InnerException;

            while (curExc != null)
            {
                sb.AppendLine(curExc.ToString());
                curExc = curExc.InnerException;
            }

            logger.LogError(100, context.Exception, sb.ToString());

            sb.Length = 0;
            sb = null;

            string message = "An error occurred, please try again or contact the administrator.";

            if (context.Exception is NotFoundException)
                message = "The object you are looking for was not found.";

            context.HttpContext.Response.Headers.Add("X-ExceptionMessage", message);

            var result = new Microsoft.AspNetCore.Mvc.ContentResult();
            result.StatusCode = 500;
            result.Content = "";
            context.Result = result;
            
        }
    }
}
