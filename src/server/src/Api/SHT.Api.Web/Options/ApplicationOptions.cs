using Microsoft.AspNetCore.Server.Kestrel.Core;
using SHT.Infrastructure.Common.Localization.Options;
using SHT.Infrastructure.DataAccess.Abstractions.Options;

namespace SHT.Api.Web.Options
{
    public class ApplicationOptions
    {
        public KestrelServerOptions Kestrel { get; set; }

        public DataAccessOptions DataAccessOptions { get; set; }

        public LocalizationOptions LocalizationOptions { get; set; }
    }
}