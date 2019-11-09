using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using SHT.Infrastructure.Common.Localization.Options;

namespace SHT.Api.Web
{
    internal class RequestLocalizationConfigurator
    {
        public static RequestLocalizationOptions GetRequestLocalizationOptions(IServiceProvider provider)
        {
            var localizationOptions = provider.GetRequiredService<LocalizationOptions>();
            var supportedCultures = localizationOptions.SupportedCultures
                .Select(culture => new CultureInfo(culture))
                .ToArray();

            var options = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(localizationOptions.DefaultCulture),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
            };

            return options;
        }
    }
}