using System;
using System.IO;
using System.Threading.Tasks;

namespace SHT.Infrastructure.FileStorage.StorageStrategies
{
    internal interface IFilesStorageStrategy
    {
        Task<FileReference> Save(Func<Stream> streamAccessor, string contentType);

        Func<Task<Stream>> Get(string fileReference);

        Task Delete(string fileReference);
    }
}