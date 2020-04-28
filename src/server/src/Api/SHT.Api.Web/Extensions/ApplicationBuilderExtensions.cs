using System;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.AspNetCore.Builder;

namespace SHT.Api.Web.Extensions
{
    internal static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseGraphQlPlayground(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UsePlayground(
                new PlaygroundOptions
                {
                    Path = "/graphql/playground",
                    EnableSubscription = false,
                    QueryPath = "/api/graphql",
                });
        }

        public static IApplicationBuilder UseGraphQlEndpoint(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseGraphQL(new QueryMiddlewareOptions
            {
                EnableSubscriptions = false,
                Path = "/api/graphql",
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