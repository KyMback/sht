using System.Threading.Tasks;
using File = SHT.Domain.Models.Files.File;

namespace SHT.Domain.Common.Files
{
    public interface IFileService
    {
        Task<File> Create(FileCreationData data);

        Task Delete(File file);
    }
}