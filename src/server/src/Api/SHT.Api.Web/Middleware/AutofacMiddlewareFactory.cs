using System;
using Microsoft.AspNetCore.Http;

namespace SHT.Api.Web.Middleware
{
    public class AutofacMiddlewareFactory : IMiddlewareFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public AutofacMiddlewareFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IMiddleware Create(Type middlewareType)
        {
            return (IMiddleware)_serviceProvider.GetService(middlewareType);
        }

        public void Release(IMiddleware middleware)
        {
        }
    }
}