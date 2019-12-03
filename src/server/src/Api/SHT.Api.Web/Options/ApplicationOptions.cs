using Microsoft.AspNetCore.Server.Kestrel.Core;
using SHT.Infrastructure.Common.Localization.Options;
using SHT.Infrastructure.Common.Options;

namespace SHT.Api.Web.Options
{
    public class ApplicationOptions
    {
        public KestrelServerOptions Kestrel { get; set; }

        public ConnectionsOptions ConnectionsOptions { get; set; }

        public LocalizationOptions LocalizationOptions { get; set; }
    }
}