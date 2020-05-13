using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SHT.BackgroundProcess.Host.Extensions
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddAppConfiguration(
            this IConfigurationBuilder configurationBuilder,
            IHostEnvironment hostEnvironment,
            string[] args)
        {
            return configurationBuilder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddJsonFile("appsettings.Personal.json", true, true)
                .AddEnvironmentVariables()
                .AddCommandLine(args);
        }

        public static IConfigurationBuilder AddHostConfiguration(
            this IConfigurationBuilder configurationBuilder,
            string[] args)
        {
            return configurationBuilder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("hostsettings.json", optional: true)
                .AddEnvironmentVariables("BG_HOST_")
                .AddCommandLine(args);
        }
    }
}
