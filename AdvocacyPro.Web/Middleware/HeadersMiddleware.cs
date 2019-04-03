using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvocacyPro.Web.Server.Middleware
{
    public class HeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public HeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("X-Frame-Options", "deny");
            httpContext.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
            httpContext.Response.Headers.Add("X-Content-Type-Options", "nosniff");

            // Call the next middleware delegate in the pipeline 
            await _next.Invoke(httpContext);
        }
    }
}
