using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SHT.Api.Web.Extensions;

namespace SHT.Api.Web.Middleware
{
    public class SpaRoutingMiddleware : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.IsSpaPageRequest())
            {
                context.Request.Path = "/index.html";
            }

            return next(context);
        }
    }
}