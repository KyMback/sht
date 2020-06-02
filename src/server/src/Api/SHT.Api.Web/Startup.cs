using Autofac;
using CorrelationId;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SHT.Api.Web.Constants;
using SHT.Api.Web.Extensions;
using SHT.Api.Web.Extensions.HangfireDashboard;
using SHT.Api.Web.Middleware;
using SHT.Api.Web.Security;
using SHT.Application;
using SHT.Domain.Common;
using SHT.Domain.Questions;
using SHT.Domain.Services;
using SHT.Domain.Users;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.Common.Extensions;
using SHT.Infrastructure.DataAccess.EF;
using SHT.Infrastructure.FileStorage;
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
                .PersistKeysToDbContext<DefaultDbContext>()
                .Services
                .AddHangfireClient(_configuration)
                .AddCustomOptions(_configuration)
                .AddCustomSecurity(_configuration)
                .AddCorrelationIdFluent()
                .AddRouting()
                .AddHttpContextAccessor()
                .AddCustomGraphQl()
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
                .UseAutoMapper()
                .UseAfterBuildInitializers()
                .AddTypeAssembly<WebApiModule>()
                .AddTypeAssembly<ApplicationModule>()
                .AddTypeAssembly<DomainQuestionsModule>()
                .AddTypeAssembly<DomainTestsModule>()
                .AddTypeAssembly<DomainUsersModule>()
                .AddTypeAssembly<DomainCommonModule>()
                .AddTypeAssembly<InfrastructureServicesModule>()
                .AddTypeAssembly<FIleStorageModule>()
                .AddTypeAssembly<InfrastructureCommonModule>()
                .AddTypeAssembly<DataAccessModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app
                .UseCorrelationId()
                .UseOptionsBasedHangfireDashboard()
                .UseGraphQlPlayground()
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
                .UseMiddleware<ExceptionHandlingMiddleware>()
                .UseGraphQlEndpoint()
                .UseCustomEndpoints();
        }
    }
}