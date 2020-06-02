using System;
using System.IO;

namespace SHT.Common.Utils
{
    public static class FileSystemUtils
    {
        public static string GetDirectoryAbsolutePath(string directory)
        {
            return !Path.IsPathRooted(directory)
                ? Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), directory))
                : directory;
        }

        public static void EnsureDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
