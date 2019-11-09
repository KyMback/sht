using System;

namespace SHT.Infrastructure.Common.Localization.Extensions
{
    public static class EnumLocalizationKeyExtensions
    {
        /// <summary>
        ///     Gets localization key for enum value.
        /// </summary>
        /// <param name="value">Value of enum to get localization key.</param>
        /// <returns>Localization key,.</returns>
        public static string GetLocalizationKey(this Enum value)
        {
            return $"{value.GetType().Name}_{value.ToString()}";
        }

        /// <summary>
        ///     Gets localization key with specific <paramref name="postfix"/> for enum value.
        /// </summary>
        /// <param name="value">Value of enum to get localization key.</param>
        /// <param name="postfix">Postfix for enum value.</param>
        /// <returns>Localization key,.</returns>
        public static string GetLocalizationKey(this Enum value, string postfix)
        {
            return $"{value.GetType().Name}_{value.ToString()}_{postfix}";
        }
    }
}