using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TravelAppWebUI.Helper.Session;

namespace TravelAppWebUI.UI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SessionCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {



            //if (httpContext.Request.Path.Value.Contains("/Admin/Login"))
            //{
            //    if (SessionManager.LoggedUser == null)
            //    {
            //        httpContext.Response.Redirect("/Admin/Login");
            //        httpContext.Response.WriteAsync("Yetksiz Giriş");
            //    }
            //}
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SessionCheckMiddlewareExtensions
    {
        public static IApplicationBuilder UseSessionCheckMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SessionCheckMiddleware>();
        }
    }
}
