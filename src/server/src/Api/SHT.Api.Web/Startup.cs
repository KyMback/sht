using System;
using Autofac;
using CorrelationId;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using HotChocolate.Execution;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SHT.Api.Web.Constants;
using SHT.Api.Web.Extensions;
using SHT.Api.Web.GraphQl;
using SHT.Api.Web.Middleware;
using SHT.Api.Web.Security;
using SHT.Application;
using SHT.Domain.Services;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.Common.Extensions;
using SHT.Infrastructure.DataAccess.EF;
using SHT.Infrastructure.Services;

namespace SHT.Api.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDataProtection()
                .Services
                .AddCustomOptions(_configuration)
                .AddCustomSecurity(_configuration)
                .AddCorrelationIdFluent()
                .AddRouting()
                .AddCustomSwagger()
                .AddHttpContextAccessor()
                .AddGraphQL(
                    provider => CustomSchemaBuilder.Configure().AddServices(provider).Create(),
                    builder => builder
                        .Use<CustomGraphQlExceptionHandlingMiddleware>()
                        .UseDefaultPipeline())
                .AddMvcCore()
                .AddCustomMvcOptions()
                .AddCustomJsonOptions()
                .AddCustomCors()
                .AddControllersAsServices()
                .AddApiExplorer();
        }

        [UsedImplicitly]
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder
                .AddTypeAssembly<WebApiModule>()
                .AddTypeAssembly<ApplicationModule>()
                .AddTypeAssembly<DomainServicesModule>()
                .AddTypeAssembly<InfrastructureServicesModule>()
                .AddTypeAssembly<InfrastructureCommonModule>()
                .AddTypeAssembly<DataAccessModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app
                .UseCorrelationId()
                .UseIf(_hostingEnvironment.IsDevelopment(), builder => builder.UsePlayground(
                    new PlaygroundOptions
                    {
                        Path = "/graphql",
                        EnableSubscription = false,
                        QueryPath = "/graphql",
                    }))
                .UseRequestLocalization(
                    RequestLocalizationConfigurator.GetRequestLocalizationOptions(app.ApplicationServices))
                .UseMiddleware<SpaRoutingMiddleware>()
                .UseCors(CorsPolicyNames.AllowAny)
                .UseIf(!_hostingEnvironment.IsDevelopment(), x => x.UseHsts())
                .UseAuthentication()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthorization()
                .UseDefaultFiles()
                .UseSwagger()
                .UseCustomSwaggerUi()
                .UseMiddleware<ExceptionHandlingMiddleware>()
                .UseGraphQL(new QueryMiddlewareOptions
                {
                    EnableSubscriptions = false,
                    Path = "/graphql",
                })
                .UseCustomEndpoints();
        }
    }
}