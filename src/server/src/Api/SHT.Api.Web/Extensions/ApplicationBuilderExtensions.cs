using System;
using Microsoft.AspNetCore.Builder;
using SHT.Api.Web.Constants;
using SHT.Api.Web.Services;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SHT.Api.Web.Extensions
{
    internal static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustomSwaggerUi(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseSwaggerUI(
                options =>
                {
                    options.DocumentTitle = AssemblyProvider.GetProductName();
                    options.RoutePrefix = RoutesConstants.SwaggerUiRoute.TrimStart('/');
                    options.DisplayRequestDuration();
                    options.DocExpansion(DocExpansion.None);
                    var versionString = $"v{AssemblyProvider.GetVersion()}";

                    options.SwaggerEndpoint(
                        $"{RoutesConstants.SwaggerJsonRoute}/{versionString}/swagger.json",
                        versionString);
                });
        }

        public static IApplicationBuilder UseCustomEndpoints(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseEndpoints(builder =>
            {
                builder.MapControllerRoute("default", "{controller}/{action}/{id?}");
            });
        }

        public static IApplicationBuilder UseIf(
            this IApplicationBuilder builder,
            bool condition,
            Func<IApplicationBuilder, IApplicationBuilder> action)
        {
            if (condition)
            {
                builder = action(builder);
            }

            return builder;
        }
    }
}