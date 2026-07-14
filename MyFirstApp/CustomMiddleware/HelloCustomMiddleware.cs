using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyFirstApp.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HelloCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public HelloCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            // Before logic
            if(httpContext.Request.Query.ContainsKey("firstName") && httpContext.Request.Query.ContainsKey("lastName"))
            {
                string fullName = httpContext.Request.Query["firstName"] + " " + httpContext.Request.Query["lastName"]+"\n";
                await httpContext.Response.WriteAsync(fullName);
            }
            //return _next(httpContext);
            // because we are in async method we must use await instead of return keyword
            await _next(httpContext);
            // After logic
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HelloCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseHelloCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HelloCustomMiddleware>();
        }
    }
}
