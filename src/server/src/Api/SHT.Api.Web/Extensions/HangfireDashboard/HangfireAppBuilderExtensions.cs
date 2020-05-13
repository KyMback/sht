using System;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SHT.Infrastructure.BackgroundProcess;

namespace SHT.Api.Web.Extensions.HangfireDashboard
{
    internal static class HangfireAppBuilderExtensions
    {
        /// <summary>
        ///     Uses hangfire based on <see cref="HangfireDashboardOptions"/>.
        ///     Adds hangfire dashboard if <see cref="HangfireDashboardOptions"/> option
        ///     <see cref="HangfireDashboardOptions.Enabled"/> is true. Adds basic authentication
        ///     based on options in <see cref="HangfireDashboardOptions"/>.
        /// </summary>
        /// <param name="builder"><see cref="IApplicationBuilder"/>.</param>
        /// <returns><see cref="IApplicationBuilder"/> for chaining.</returns>
        /// <remarks>
        ///     The order registration is critical for functionality:
        ///     should be added before any custom middleware which may change <see cref="HttpContext.Response"/>.
        /// </remarks>
        public static IApplicationBuilder UseOptionsBasedHangfireDashboard(this IApplicationBuilder builder)
        {
            var customOptions = builder.ApplicationServices
                .GetRequiredService<IOptions<HangfireDashboardOptions>>()
                .Value;

            if (customOptions.Enabled)
            {
                ValidateOptions(customOptions);
                UseDashboardWithBasicAuth(builder, customOptions);
            }

            return builder;
        }

        private static void UseDashboardWithBasicAuth(IApplicationBuilder builder, HangfireDashboardOptions options)
        {
            builder.UseHangfireDashboard(
                options.Route,
                new DashboardOptions
                {
                    Authorization = new[]
                    {
                        new HangfireBasicAuthFilter(options),
                    },
                });
        }

        private static void ValidateOptions(HangfireDashboardOptions options)
        {
            if (options.Enabled && (!AreCredentialsValid(options) || !IsRouteValid(options)))
            {
                throw new InvalidOperationException($"Unable to perform {nameof(UseOptionsBasedHangfireDashboard)}. Options invalid.");
            }
        }

        private static bool AreCredentialsValid(HangfireDashboardOptions options)
        {
            return !string.IsNullOrWhiteSpace(options.Username) && !string.IsNullOrWhiteSpace(options.Password);
        }

        private static bool IsRouteValid(HangfireDashboardOptions options)
        {
            return !string.IsNullOrWhiteSpace(options.Route) && options.Route.StartsWith("/", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
