using Microsoft.Extensions.Configuration;

namespace SHT.Infrastructure.Common.Extensions
{
    public static class ConfigurationExtensions
    {
        public static T GetSection<T>(this IConfiguration configuration, string key = null)
            where T : new()
        {
            if (key == null)
            {
                key = typeof(T).Name;
            }

            var section = new T();
            configuration.GetSection(key).Bind(section);
            return section;
        }
    }
}