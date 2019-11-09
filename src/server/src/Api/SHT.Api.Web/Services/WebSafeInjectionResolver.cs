using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SHT.Infrastructure.Common;

namespace SHT.Api.Web.Services
{
    internal class WebSafeInjectionResolver : ISafeInjectionResolver
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WebSafeInjectionResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public T Resolve<T>()
        {
            return _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<T>();
        }

        public object Resolve(Type type)
        {
            return _httpContextAccessor.HttpContext.RequestServices.GetRequiredService(type);
        }
    }
}