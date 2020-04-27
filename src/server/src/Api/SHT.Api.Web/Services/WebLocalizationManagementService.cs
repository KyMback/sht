using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using SHT.Infrastructure.Common.Localization;
using SHT.Infrastructure.Common.Localization.Options;

namespace SHT.Api.Web.Services
{
    public class WebLocalizationManagementService : ILocalizationManagementService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LocalizationOptions _localizationOptions;

        public WebLocalizationManagementService(
            IHttpContextAccessor httpContextAccessor,
            LocalizationOptions localizationOptions)
        {
            _httpContextAccessor = httpContextAccessor;
            _localizationOptions = localizationOptions;
        }

        public Task SetCulture(CultureInfo info)
        {
            ThrowIfCultureNotSupported(info);

            _httpContextAccessor.HttpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(info)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return Task.CompletedTask;
        }

        private void ThrowIfCultureNotSupported(CultureInfo info)
        {
            if (_localizationOptions.SupportedCultures.All(e => e != info.Name))
            {
                throw new ArgumentException($"Culture: {info.Name} is not supported yet.");
            }
        }
    }
}