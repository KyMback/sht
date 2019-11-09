using System;
using System.IO;
using System.Reflection;
using CorrelationId;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SHT.Api.Web.OperationFilters;
using SHT.Api.Web.Services;
using SHT.Infrastructure.Common.Localization.Options;
using SHT.Resources;

namespace SHT.Api.Web.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCorrelationIdFluent(this IServiceCollection services)
        {
            services.AddCorrelationId();
            return services;
        }

        public static IServiceCollection AddCustomOptions(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .Configure<ApplicationOptions>(configuration)
                .AddSingleton(x => x.GetRequiredService<IOptions<ApplicationOptions>>().Value)
                .AddSingleton(x => x.GetRequiredService<ApplicationOptions>().ConnectionsOptions)
                .AddSingleton(x => CreateLocalizationOptions(configuration));

            return services;
        }

        public static IServiceCollection AddCustomRouting(this IServiceCollection services)
        {
            return services.AddRouting(options => { options.LowercaseUrls = true; });
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(
                options =>
                {
                    options.DescribeAllParametersInCamelCase();
                    options.OperationFilter<CorrelationIdOperationFilter>();
                    options.OperationFilter<InternalServerErrorOperationFilter>();

                    var versionString = $"v{AssemblyProvider.GetVersion()}";

                    var info = new OpenApiInfo
                    {
                        Title = AssemblyProvider.GetProductName(),
                        Description = AssemblyProvider.GetDescription(),
                        Version = versionString,
                    };

                    options.SwaggerDoc(versionString, info);

                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    options.IncludeXmlComments(xmlPath);
                });
        }

        private static LocalizationOptions CreateLocalizationOptions(
            IConfiguration configuration)
        {
            return new LocalizationOptions
            {
                SupportedCultures = configuration.GetSection("LocalizationOptions:SupportedCultures").Get<string[]>(),
                DefaultCulture = configuration.GetValue<string>("LocalizationOptions:DefaultCulture"),
                Sources = new[]
                {
                    new LocalizationSource(ResourceMap.GetLocalizationsRootPath(), LocalizationSourceType.Common),
                },
            };
        }
    }
}