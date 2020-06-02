using System;
using CorrelationId;
using Hangfire;
using Hangfire.PostgreSql;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SHT.Api.Web.Constants;
using SHT.Api.Web.GraphQl;
using SHT.Api.Web.GraphQl.Common;
using SHT.Api.Web.GraphQl.Mutations;
using SHT.Api.Web.GraphQl.Queries;
using SHT.Api.Web.Options;
using SHT.Api.Web.Security;
using SHT.Infrastructure.BackgroundProcess;
using SHT.Infrastructure.Common.Localization.Options;
using SHT.Infrastructure.Common.Options;
using SHT.Infrastructure.DataAccess.Abstractions.Options;
using SHT.Infrastructure.FileStorage.Options;
using SHT.Infrastructure.Services;
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

        public static IServiceCollection AddCustomGraphQl(this IServiceCollection collection)
        {
            var customOptions = new QueryExecutionOptions
            {
                ForceSerialExecution = true,
            };

            return collection
                .AddGraphQL(
                    provider => SchemaBuilder.New()
                        .AddAuthorizeDirectiveType()
                        // To restrict max number of fields in one page
                        .AddType(new PaginationAmountType(100))
                        .ModifyOptions(e =>
                        {
                            e.DefaultBindingBehavior = BindingBehavior.Explicit;
                            e.UseXmlDocumentation = true;
                        })
                        .BindClrType<Unit, VoidType>()
                        .AddMutationType<GraphQlMutations>()
                        .AddQueryType<GraphQlQueries>()
                        .AddServices(provider)
                        .Create(),
                    builder => builder
                        .Use<CustomGraphQlExceptionHandlingMiddleware>()
                        .UseDefaultPipeline())
                .AddSingleton<IExecutionStrategyOptionsAccessor>(provider => customOptions);
        }

        public static IServiceCollection AddHangfireClient(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString =
                configuration.GetValue<string>("DataAccessOptions:ConnectionsOptions:DefaultConnection");
            return services
                .AddHangfire(settings => settings.UsePostgreSqlStorage(connectionString));
        }

        public static IServiceCollection AddCustomOptions(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .Configure<ApplicationOptions>(configuration)
                .Configure<HangfireDashboardOptions>(configuration.GetSection(nameof(HangfireDashboardOptions)))
                .Configure<DataAccessOptions>(configuration.GetSection(nameof(DataAccessOptions)))
                .Configure<IdentityOptions>(configuration.GetSection(nameof(IdentityOptions)))
                .Configure<RouteOptions>(configuration.GetSection(nameof(RouteOptions)))
                .Configure<MvcOptions>(configuration.GetSection(nameof(MvcOptions)))
                .Configure<JsonOptions>(configuration.GetSection(nameof(JsonOptions)))
                .Configure<EmailOptions>(configuration.GetSection(nameof(EmailOptions)))
                .Configure<FileStorageOptions>(configuration.GetSection(nameof(FileStorageOptions)))
                .Configure<FileSystemStorageOptions>(configuration.GetSection($"{nameof(FileStorageOptions)}:{nameof(FileSystemStorageOptions)}"))
                .Configure<LocalizationOptions>(configuration.GetSection(nameof(LocalizationOptions)))
                .Configure<TokensOptions>(configuration.GetSection(nameof(TokensOptions)))
                .Configure<EmailConfirmationTokenProviderOptions>(
                    configuration.GetSection($"{nameof(TokensOptions)}:ConfirmEmail"))
                .Configure<LocalizationOptions>(CreateLocalizationOptions)
                .AddSingleton(x => CreateRouteOptions(configuration))
                .AddSingleton(x => x.GetRequiredService<IOptions<LocalizationOptions>>().Value);
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
            var applicationUri = configuration.GetValue<Uri>(nameof(ApplicationOptions.ApplicationUri));
            return new RoutesOptions
            {
                EmailConfirmationUri = new Uri(applicationUri, RoutesConstants.EmailConfirmation),
            };
        }
    }
}