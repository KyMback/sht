using System.Collections.Generic;

namespace SHT.Infrastructure.Common.Localization.Options
{
    public class LocalizationOptions
    {
        public IReadOnlyCollection<string> SupportedCultures { get; set; }

        public string DefaultCulture { get; set; }

        public IReadOnlyCollection<LocalizationSource> Sources { get; set; }
    }
}