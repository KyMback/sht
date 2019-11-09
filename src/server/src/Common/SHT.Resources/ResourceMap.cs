using System.IO;

namespace SHT.Resources
{
    public static class ResourceMap
    {
        private const string LocalizationsDir = "Localizations";

        public static string GetLocalizationsRootPath()
        {
            var assemblyDir = GetAssemblyDir();
            return Path.Combine(assemblyDir, LocalizationsDir);
        }

        private static string GetAssemblyDir()
        {
            var assembly = typeof(ResourceMap).Assembly;
            return Path.GetDirectoryName(assembly.Location);
        }
    }
}