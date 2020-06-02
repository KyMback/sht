using System;
using System.IO;
using System.Threading.Tasks;
using SHT.Infrastructure.FileStorage.StorageStrategies;

namespace SHT.Infrastructure.FileStorage
{
    public interface IFilesStorage
    {
        Task<FileReference> Save(Func<Stream> streamAccessor, string contentType);

        Func<Task<Stream>> Get(string fileReference);

        Task Delete(string fileReference);
    }
}