using System;
using System.Globalization;
using Microsoft.Extensions.Logging;

namespace SHT.Infrastructure.Common.Localization.Extensions
{
    internal static class JsonStringLocalizerLoggerExtensions
    {
        private static readonly Action<ILogger, string, string, CultureInfo, Exception> SearchedLocation =
            LoggerMessage.Define<string, string, CultureInfo>(
                LogLevel.Warning,
                1,
                $"{nameof(JsonStringLocalizer)} searched for '{{Key}}' in '{{LocationSearched}}' with culture '{{Culture}}'. Localization not found.");

        /// <summary>
        ///     Logs resource resolution.
        /// </summary>
        /// <param name="logger">The instance of <see cref="ILogger" />.</param>
        /// <param name="key">Key to get localization.</param>
        /// <param name="searchedLocation">Searched value.</param>
        /// <param name="culture">Culture.</param>
        public static void LocalizationNotFound(this ILogger logger, string key, string searchedLocation, CultureInfo culture)
        {
            SearchedLocation(logger, key, searchedLocation, culture, null);
        }
    }
}