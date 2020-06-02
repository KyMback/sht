using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using SHT.Application;
using SHT.BackgroundProcess.Host.Extensions;
using SHT.BackgroundProcess.Host.Services.Hosted;
using SHT.BackgroundProcess.Jobs;
using SHT.Common;
using SHT.Domain.Common;
using SHT.Domain.Questions;
using SHT.Domain.Services;
using SHT.Domain.Users;
using SHT.Infrastructure.BackgroundProcess;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.Common.Extensions;
using SHT.Infrastructure.DataAccess.EF;
using SHT.Infrastructure.FileStorage;
using SHT.Infrastructure.Services;

namespace SHT.BackgroundProcess.Host
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            Log.Logger = BuildLogger(host);

            try
            {
                Log.Information("Background host started");
                host.Run();
                Log.Information("Background host stopped");
                return (int)ProgramExitCode.Success;
            }
            catch (Exception exception)
            {
                Log.Fatal(exception, "Background host terminated unexpectedly");
                return (int)ProgramExitCode.Error;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return new HostBuilder()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureHostConfiguration(builder => builder.AddHostConfiguration(args))
                .ConfigureAppConfiguration((context, builder) =>
                    builder.AddAppConfiguration(context.HostingEnvironment, args))
                .ConfigureServices((context, services) =>
                {
                    services
                        .AddCustomOptions(context.Configuration)
                        .ConfigureHangfire(context.Configuration)
                        .AddHostedService<RecurringJobsService>()
                        .AddHostedService<HangfireHostedService>();
                })
                .UseSerilog()
                .ConfigureContainer<ContainerBuilder>((_, builder) => ConfigureContainer(builder));
        }

        private static void ConfigureContainer(ContainerBuilder builder)
        {
            builder
                .RegisterBuildCallback(container => GlobalConfiguration.Configuration.UseAutofacActivator(container))
                .UseAutoMapper()
                .UseAfterBuildInitializers()
                .AddTypeAssembly<BackgroundProcessJobsModule>()
                .AddTypeAssembly<BackgroundProcessHostModule>()
                .AddTypeAssembly<DataAccessModule>()
                .AddTypeAssembly<ApplicationModule>()
                .AddTypeAssembly<DomainQuestionsModule>()
                .AddTypeAssembly<DomainTestsModule>()
                .AddTypeAssembly<DomainUsersModule>()
                .AddTypeAssembly<DomainCommonModule>()
                .AddTypeAssembly<InfrastructureServicesModule>()
                .AddTypeAssembly<InfrastructureCommonModule>()
                .AddTypeAssembly<FIleStorageModule>()
                .AddTypeAssembly<InfrastructureBackgroundProcessModule>()
                .AddTypeAssembly<InfrastructureServicesModule>();
        }

        private static Logger BuildLogger(IHost webHost)
        {
            return new LoggerConfiguration()
                .ReadFrom.Configuration(webHost.Services.GetRequiredService<IConfiguration>())
                .CreateLogger();
        }
    }
}