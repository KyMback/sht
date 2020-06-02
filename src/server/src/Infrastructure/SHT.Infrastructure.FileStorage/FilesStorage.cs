using System;
using System.IO;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using Microsoft.Extensions.Options;
using SHT.Infrastructure.FileStorage.Options;
using SHT.Infrastructure.FileStorage.StorageStrategies;

namespace SHT.Infrastructure.FileStorage
{
    internal class FilesStorage : IFilesStorage
    {
        private readonly IIndex<FileStorageType, IFilesStorageStrategy> _storageStrategies;
        private readonly IOptions<FileStorageOptions> _fileStorageOptions;

        public FilesStorage(
            IIndex<FileStorageType, IFilesStorageStrategy> storageStrategies,
            IOptions<FileStorageOptions> fileStorageOptions)
        {
            _storageStrategies = storageStrategies;
            _fileStorageOptions = fileStorageOptions;
        }

        public Task<FileReference> Save(Func<Stream> streamAccessor, string contentType)
        {
            return GetStorage(_fileStorageOptions).Save(streamAccessor, contentType);
        }

        public Func<Task<Stream>> Get(string fileReference)
        {
            return GetStorage(_fileStorageOptions).Get(fileReference);
        }

        public Task Delete(string fileReference)
        {
            return GetStorage(_fileStorageOptions).Delete(fileReference);
        }

        private IFilesStorageStrategy GetStorage(IOptions<FileStorageOptions> options)
        {
            return _storageStrategies[options.Value.StorageType];
        }
    }
}