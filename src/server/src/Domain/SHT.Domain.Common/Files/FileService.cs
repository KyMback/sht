using System.Threading.Tasks;
using AutoMapper;
using SHT.Domain.Models.Files;
using SHT.Infrastructure.DataAccess.Abstractions;
using SHT.Infrastructure.FileStorage;
using SHT.Infrastructure.FileStorage.StorageStrategies;

namespace SHT.Domain.Common.Files
{
    internal class FileService : IFileService
    {
        private readonly IFilesStorage _filesStorage;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FileService(
            IFilesStorage filesStorage,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _filesStorage = filesStorage;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<File> Create(FileCreationData data)
        {
            var file = _mapper.Map<File>(data);
            FileReference reference = await _filesStorage.Save(data.StreamAccessor, data.ContentType);
            file.Reference = reference.Reference;
            file.StorageType = reference.StorageType;

            return await _unitOfWork.Add(file);
        }

        public async Task Delete(File file)
        {
            await _unitOfWork.Delete(file);
            await _filesStorage.Delete(file.Reference);
        }
    }
}