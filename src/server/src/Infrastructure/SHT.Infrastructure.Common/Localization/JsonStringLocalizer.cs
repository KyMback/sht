using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SHT.Infrastructure.Common.Localization.Extensions;
using SHT.Infrastructure.Common.Localization.Options;

namespace SHT.Infrastructure.Common.Localization
{
    public class JsonStringLocalizer : IStringLocalizer
    {
        private static readonly ConcurrentDictionary<string, Dictionary<string, string>> ResourcesCache =
            new ConcurrentDictionary<string, Dictionary<string, string>>();

        private readonly CultureInfo _cultureInfo;
        private readonly ILogger<JsonStringLocalizer> _logger;
        private readonly IEnumerable<LocalizationSource> _sources;

        private readonly string _searchedLocations;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonStringLocalizer" /> class.
        /// </summary>
        /// <param name="sources">Paths to resources.</param>
        /// <param name="cultureInfo">Culture info.</param>
        /// <param name="logger">The instance of <see cref="ILogger" />.</param>
        public JsonStringLocalizer(
            IEnumerable<LocalizationSource> sources,
            CultureInfo cultureInfo,
            ILogger<JsonStringLocalizer> logger)
        {
            _sources = sources ?? throw new ArgumentNullException(nameof(sources));
            _cultureInfo = cultureInfo;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            if (!ResourcesCache.ContainsKey(_cultureInfo.Name))
            {
                ResourcesCache[_cultureInfo.Name] = GetLocalization();
            }

            _searchedLocations = string.Join(";", _sources);
        }

        public LocalizedString this[string name]
        {
            get
            {
                var value = GetStringSafely(name);

                return new LocalizedString(name, value ?? name, value == null, _searchedLocations);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var format = GetStringSafely(name);
                var value = string.Format(CultureInfo.InvariantCulture, format ?? name, arguments);

                return new LocalizedString(name, value, format == null, _searchedLocations);
            }
        }

        /// <inheritdoc />
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return GetAllStrings(includeParentCultures, _cultureInfo);
        }

        /// <inheritdoc />
        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return new JsonStringLocalizer(_sources, culture, _logger);
        }

        private static IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures, CultureInfo culture)
        {
            if (ResourcesCache.TryGetValue(culture.Name, out var values))
            {
                var localizedStrings = values.Select(pair => new LocalizedString(pair.Key, pair.Value));
                if (includeParentCultures)
                {
                    var parentCultureLocalizedStrings =
                        GetAllStrings(includeParentCultures: false, culture: culture.Parent);
                    return localizedStrings.Concat(parentCultureLocalizedStrings);
                }

                return localizedStrings;
            }

            return Enumerable.Empty<LocalizedString>();
        }

        private Dictionary<string, string> GetLocalization()
        {
            return Merge(_sources.Select(GetLocalization).SelectMany(i => i));
        }

        private Dictionary<string, string> GetLocalization(LocalizationSource source)
        {
            string[] filePaths = FindFiles(source.Path, $"*{_cultureInfo.Name}*.json");
            var entries = filePaths.SelectMany(ReadFile);
            return Merge(entries);
        }

        private Dictionary<string, string> Merge(IEnumerable<KeyValuePair<string, string>> entries)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var entry in entries)
            {
                if (dictionary.ContainsKey(entry.Key))
                {
                    _logger.LogWarning($"Localization sources contains duplicate keys: {entry.Key}");
                    continue;
                }

                dictionary.Add(entry.Key, entry.Value);
            }

            return dictionary;
        }

        private IDictionary<string, string> ReadFile(string filePath)
        {
            var fileText = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Dictionary<string, string>>(fileText);
        }

        private string[] FindFiles(string directory, string pattern)
        {
            return Directory.Exists(directory)
                ? Directory.GetFiles(directory, pattern)
                : Array.Empty<string>();
        }

        private string GetStringSafely(string name)
        {
            if (!ResourcesCache.TryGetValue(_cultureInfo.Name, out var resources))
            {
                throw new ArgumentException($"There is no localization for [{_cultureInfo.Name}] culture.");
            }

            var resource = resources?.SingleOrDefault(s => s.Key == name);
            if (resource == null)
            {
                _logger.LocalizationNotFound(name, _searchedLocations, _cultureInfo);
            }

            return resource?.Value;
        }
    }
}