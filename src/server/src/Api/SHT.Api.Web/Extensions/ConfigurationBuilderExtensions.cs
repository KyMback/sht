using System;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SHT.Api.Web.Extensions
{
    internal static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddCustomConfiguration(
            this IConfigurationBuilder builder,
            IWebHostEnvironment environment,
            string[] args)
        {
            return builder
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
                .AddJsonFile("appsettings.Personal.json", true, true)
                .AddIf(
                    environment.IsDevelopment(),
                    x => x.AddUserSecrets(Assembly.GetExecutingAssembly(), true))
                .AddEnvironmentVariables()
                .AddIf(
                    args != null,
                    x => x.AddCommandLine(args));
        }

        private static IConfigurationBuilder AddIf(
            this IConfigurationBuilder builder,
            bool condition,
            Func<IConfigurationBuilder, IConfigurationBuilder> action)
        {
            if (condition)
            {
                action(builder);
            }

            return builder;
        }
    }
}