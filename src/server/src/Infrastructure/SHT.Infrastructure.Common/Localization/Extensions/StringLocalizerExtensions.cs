using System;
using Microsoft.Extensions.Localization;

namespace SHT.Infrastructure.Common.Localization.Extensions
{
    public static class StringLocalizerExtensions
    {
        /// <summary>
        ///     Localizes enum value.
        /// </summary>
        /// <param name="localizer"><see cref="IStringLocalizer"/>.</param>
        /// <param name="value">Enum value to localize.</param>
        /// <returns>Localized string.</returns>
        public static string Enum(this IStringLocalizer localizer, Enum value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return localizer[value.GetLocalizationKey()];
        }

        /// <summary>
        ///     Localizes enum value.
        /// </summary>
        /// <param name="localizer"><see cref="IStringLocalizer"/>.</param>
        /// <param name="value">Enum value to localize.</param>
        /// <param name="postfix">Postfix for enum value.</param>
        /// <returns>Localized string.</returns>
        public static string Enum(this IStringLocalizer localizer, Enum value, string postfix)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return localizer[value.GetLocalizationKey(postfix)];
        }

        /// <summary>
        ///     Get the localized "None" value.
        /// </summary>
        /// <param name="localizer"><see cref="IStringLocalizer"/>.</param>
        /// <returns>Localized value.</returns>
        public static string None(this IStringLocalizer localizer)
        {
            return localizer["None"];
        }
    }
}