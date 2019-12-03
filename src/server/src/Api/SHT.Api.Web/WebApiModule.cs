using Autofac;
using Microsoft.AspNetCore.Http;
using SHT.Api.Web.Middleware;
using SHT.Api.Web.Security;
using SHT.Api.Web.Security.Services;
using SHT.Api.Web.Services;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.Common.Extensions;

namespace SHT.Api.Web
{
    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterMiddleware(builder);

            builder
                .AddSingleAsImplementedInterfaces<WebSafeInjectionResolver>()
                .AddSingleAsImplementedInterfaces<WebExecutionContextAccessor>()
                .AddScopedAsImplementedInterfaces<WebAuthenticationService>();
        }

        private void RegisterMiddleware(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AssignableTo<IMiddleware>()
                .AsSelf()
                .SingleInstance();

            builder.AddScopedAsImplementedInterfaces<AutofacMiddlewareFactory>();
        }
    }
}