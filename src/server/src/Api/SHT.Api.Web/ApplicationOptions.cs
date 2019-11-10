using Microsoft.AspNetCore.Server.Kestrel.Core;
using SHT.Api.Web.Security.Options;
using SHT.Infrastructure.Common.Localization.Options;
using SHT.Infrastructure.Common.Options;

namespace SHT.Api.Web
{
    public class ApplicationOptions
    {
        public KestrelServerOptions Kestrel { get; set; }

        public ConnectionsOptions ConnectionsOptions { get; set; }

        public LocalizationOptions LocalizationOptions { get; set; }

        public AuthOptions AuthOptions { get; set; }
    }
}