using System;
using System.IO;
using System.Reflection;
using CorrelationId;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SHT.Api.Web.Constants;
using SHT.Api.Web.OperationFilters;
using SHT.Api.Web.Options;
using SHT.Api.Web.Security;
using SHT.Api.Web.Services;
using SHT.Infrastructure.Common.Localization.Options;
using SHT.Infrastructure.Common.Options;
using SHT.Infrastructure.DataAccess.Abstractions.Options;
using SHT.Infrastructure.Services.Abstractions;
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
                .Configure<DataAccessOptions>(configuration.GetSection(nameof(ApplicationOptions.DataAccessOptions)))
                .Configure<IdentityOptions>(configuration.GetSection(nameof(IdentityOptions)))
                .Configure<RouteOptions>(configuration.GetSection(nameof(RouteOptions)))
                .Configure<MvcOptions>(configuration.GetSection(nameof(MvcOptions)))
                .Configure<JsonOptions>(configuration.GetSection(nameof(JsonOptions)))
                .Configure<EmailOptions>(configuration.GetSection(nameof(EmailOptions)))
                .Configure<LocalizationOptions>(configuration.GetSection(nameof(LocalizationOptions)))
                .Configure<TokensOptions>(configuration.GetSection(nameof(TokensOptions)))
                .Configure<EmailConfirmationTokenProviderOptions>(
                    configuration.GetSection($"{nameof(TokensOptions)}:ConfirmEmail"))
                .Configure<LocalizationOptions>(CreateLocalizationOptions)
                .AddSingleton(x => x.GetRequiredService<IOptions<ApplicationOptions>>().Value)
                .AddSingleton(x => CreateRouteOptions(configuration))
                .AddSingleton(x => x.GetRequiredService<IOptions<LocalizationOptions>>().Value);

            return services;
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

        private static void CreateLocalizationOptions(LocalizationOptions options)
        {
            options.Sources = new[]
            {
                new LocalizationSource(ResourceMap.GetLocalizationsRootPath(), LocalizationSourceType.Common),
            };
        }

        private static RoutesOptions CreateRouteOptions(IConfiguration configuration)
        {
            var applicationUri = configuration.GetValue<Uri>(ApplicationOptionsKeys.ApplicationUri);
            return new RoutesOptions
            {
                EmailConfirmationUri = new Uri(applicationUri, RoutesConstants.EmailConfirmation),
            };
        }
    }
}