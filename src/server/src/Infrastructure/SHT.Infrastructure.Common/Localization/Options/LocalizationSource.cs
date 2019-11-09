namespace SHT.Infrastructure.Common.Localization.Options
{
    public class LocalizationSource
    {
        public LocalizationSource(string path, LocalizationSourceType type)
        {
            Path = path;
            Type = type;
        }

        public string Path { get; }

        public LocalizationSourceType Type { get; }
    }
}