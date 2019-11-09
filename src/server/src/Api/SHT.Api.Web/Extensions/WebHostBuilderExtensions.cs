using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace SHT.Api.Web.Extensions
{
    internal static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder UseIf(
            this IWebHostBuilder hostBuilder,
            bool condition,
            Action<IWebHostBuilder> action)
        {
            if (condition)
            {
                action(hostBuilder);
            }

            return hostBuilder;
        }

        public static IWebHostBuilder UseClientDistAsWebRoot(this IWebHostBuilder builder)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..", "client", "build");
            return builder.UseWebRoot(path);
        }
    }
}