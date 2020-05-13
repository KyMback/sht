using System;
using System.Globalization;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SHT.Infrastructure.Common.Localization.Options;
using SHT.Infrastructure.DataAccess.Abstractions.Options;
using SHT.Resources;

namespace SHT.BackgroundProcess.Host.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureHangfire(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString =
                configuration.GetValue<string>("DataAccessOptions:ConnectionsOptions:DefaultConnection");
            GlobalConfiguration.Configuration
                .UseRecommendedSerializerSettings()
                .UseSimpleAssemblyNameTypeSerializer()
                .UseSerilogLogProvider()
                .UsePostgreSqlStorage(connectionString);

            return services;
        }

        public static IServiceCollection AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .Configure<DataAccessOptions>(configuration.GetSection(nameof(DataAccessOptions)))
                .Configure<LocalizationOptions>(configuration.GetSection(nameof(LocalizationOptions)))
                .Configure<LocalizationOptions>(CreateLocalizationOptions)
                .AddSingleton(x => x.GetRequiredService<IOptions<LocalizationOptions>>().Value);

            return services;
        }

        private static void CreateLocalizationOptions(LocalizationOptions options)
        {
            options.Sources = new[]
            {
                new LocalizationSource(ResourceMap.GetLocalizationsRootPath(), LocalizationSourceType.Common),
            };

            SetDefaultCulture(options);
        }

        private static void SetDefaultCulture(LocalizationOptions options)
        {
            var cultureInfo = new CultureInfo(options.DefaultCulture);

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
        }
    }
}
