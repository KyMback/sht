using System;
using System.IO;
using System.Linq;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using SHT.Api.Web.Extensions;
using SHT.Api.Web.Options;
using SHT.Common;

namespace SHT.Api.Web
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            return LogAndRun(CreateHostBuilder(args).Build());
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ==
                                 Environments.Development;

            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseKestrel(
                            (builderContext, options) =>
                            {
                                options.AddServerHeader = false;
                                options.Configure(builderContext.Configuration.GetSection("Kestrel"));

                                // Configuring Limits from appsettings.json is not supported. So we manually copy them from config.
                                // See https://github.com/aspnet/KestrelHttpServer/issues/2216
                                var kestrelOptions =
                                    builderContext.Configuration.GetTypedSection<KestrelServerOptions>(
                                        nameof(ApplicationOptions.Kestrel));
                                foreach (var property in typeof(KestrelServerLimits).GetProperties()
                                    .Where(p => p.CanWrite))
                                {
                                    var value = property.GetValue(kestrelOptions.Limits);
                                    property.SetValue(options.Limits, value);
                                }
                            })
                        .ConfigureAppConfiguration((context, builder) =>
                            builder.AddCustomConfiguration(context.HostingEnvironment, args))
                        .UseIIS()
                        .UseIISIntegration()
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseIf(isDevelopment, b => b.UseClientDistAsWebRoot())
                        .UseStartup<Startup>();
                });
        }

        private static int LogAndRun(IHost webHost)
        {
            Log.Logger = BuildLogger(webHost);

            try
            {
                Log.Information("Starting application");
                webHost.Run();
                Log.Information("Stopped application");
                return (int)ProgramExitCode.Success;
            }
            catch (Exception exception)
            {
                Log.Fatal(exception, "Application terminated unexpectedly");
                return (int)ProgramExitCode.Error;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static Logger BuildLogger(IHost webHost)
        {
            return new LoggerConfiguration()
                .ReadFrom.Configuration(webHost.Services.GetRequiredService<IConfiguration>())
                .CreateLogger();
        }
    }
}