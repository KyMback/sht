using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SHT.Infrastructure.Common.Localization.Options;
using LocalizationOptions = SHT.Infrastructure.Common.Localization.Options.LocalizationOptions;

namespace SHT.Infrastructure.Common.Localization
{
    public class JsonStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly LocalizationOptions _localizationOptions;

        public JsonStringLocalizerFactory(
            LocalizationOptions localizationOptions,
            ILoggerFactory loggerFactory)
        {
            _localizationOptions = localizationOptions ?? throw new ArgumentNullException(nameof(localizationOptions));
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        /// <inheritdoc />
        public IStringLocalizer Create(Type resourceSource)
        {
            return CreateJsonStringLocalizer(_localizationOptions.Sources);
        }

        /// <inheritdoc />
        public IStringLocalizer Create(string baseName, string location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            return CreateJsonStringLocalizer(new[]
            {
                new LocalizationSource(location, LocalizationSourceType.Common),
            });
        }

        private JsonStringLocalizer CreateJsonStringLocalizer(IEnumerable<LocalizationSource> sources)
        {
            return new JsonStringLocalizer(
                sources,
                CultureInfo.CurrentCulture,
                _loggerFactory.CreateLogger<JsonStringLocalizer>());
        }
    }
}