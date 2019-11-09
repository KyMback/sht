using Microsoft.Extensions.Configuration;
using SHT.Database.EF.Migrations.Settings;

namespace SHT.Database.EF.Migrations
{
    internal static class AppConfigurationBuilder
    {
        public static ApplicationSettings Build()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("appsettings.Personal.json", true, true)
                .AddEnvironmentVariables()
                .Build()
                .Get<ApplicationSettings>();
        }
    }
}