using System;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace SHT.Api.Web.Options
{
    public class ApplicationOptions
    {
        public KestrelServerOptions Kestrel { get; set; }

        public Uri ApplicationUri { get; set; }
    }
}