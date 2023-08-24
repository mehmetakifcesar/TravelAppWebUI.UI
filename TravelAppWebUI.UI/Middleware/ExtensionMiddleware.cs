using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TravelAppWebUI.UI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExtensionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExtensionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                httpContext.Response.Redirect("/ErrorPage/500.html");
            }


        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExtensionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExtensionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExtensionMiddleware>();
        }
    }
}
