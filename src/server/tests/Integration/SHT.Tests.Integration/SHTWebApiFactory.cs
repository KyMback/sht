using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using SHT.Api.Web;

namespace SHT.Tests.Integration
{
    public class SHTWebApiFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .UseWebRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) => config.AddConfiguration(GetTestConfiguration()));

            base.ConfigureWebHost(builder);
        }

        private static IConfiguration GetTestConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false)
                .AddJsonFile("appsettings.Personal.json", true, false)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}