using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SHT.Common.Utils;
using SHT.Infrastructure.FileStorage.Options;

namespace SHT.Infrastructure.FileStorage.StorageStrategies.FileSystem
{
    internal class FilesSystemStorageStrategy : IFilesStorageStrategy
    {
        private readonly IOptions<FileSystemStorageOptions> _fileStorageOptions;

        public FilesSystemStorageStrategy(IOptions<FileSystemStorageOptions> fileStorageOptions)
        {
            _fileStorageOptions = fileStorageOptions;
        }

        public async Task<FileReference> Save(Func<Stream> streamAccessor, string contentType)
        {
            var rootPath = FileSystemUtils.GetDirectoryAbsolutePath(_fileStorageOptions.Value.Directory);
            FileSystemUtils.EnsureDirectoryExists(rootPath);
            string fileReference = Guid.NewGuid().ToString();

            using Stream fileStream = streamAccessor();
            using var saveFileStream = new FileStream(
                GetFilePath(rootPath, fileReference),
                FileMode.CreateNew,
                FileAccess.Write,
                FileShare.None);

            if (fileStream.CanSeek)
            {
                fileStream.Seek(0, SeekOrigin.Begin);
            }

            await fileStream.CopyToAsync(saveFileStream);

            return new FileReference(FileStorageType.FileSystem, fileReference);
        }

        public Func<Task<Stream>> Get(string fileReference)
        {
            string filePath = EnsureFileExist(fileReference);

            return async () =>
            {
                using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var tempFileStream = File.Open(Path.GetTempFileName(), FileMode.Open, FileAccess.ReadWrite);
                await fileStream.CopyToAsync(tempFileStream);
                tempFileStream.Seek(0, SeekOrigin.Begin);
                return tempFileStream;
            };
        }

        public Task Delete(string fileReference)
        {
            string filePath = EnsureFileExist(fileReference);
            File.Delete(filePath);

            return Task.CompletedTask;
        }

        private string EnsureFileExist(string fileReference)
        {
            var rootPath = FileSystemUtils.GetDirectoryAbsolutePath(_fileStorageOptions.Value.Directory);
            string filePath = GetFilePath(rootPath, fileReference);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File with reference [{fileReference}] wasn't found in storage.");
            }

            return filePath;
        }

        private string GetFilePath(string rootPath, string fileReference)
        {
            return Path.Combine(rootPath, fileReference);
        }
    }
}