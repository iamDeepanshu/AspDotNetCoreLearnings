using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MiddlewareExample.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class NameCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public NameCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
           if( httpContext.Request.Query.ContainsKey("firstname") && httpContext.Request.Query.ContainsKey("lastname"))
            {
               string fullname = httpContext.Request.Query["firstname"] + httpContext.Request.Query["lastname"];

               await httpContext.Response.WriteAsync(fullname);
            }
           //before logic
            await _next(httpContext);
            //after logic
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class NameCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseNameCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NameCustomMiddleware>();
        }
    }
}
