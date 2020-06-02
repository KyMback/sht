using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Files.Contracts;
using SHT.Domain.Common.Files;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Files.Upload
{
    [UsedImplicitly]
    internal class UploadFileHandler : IRequestHandler<UploadFileRequest, FileInfoDto>
    {
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UploadFileHandler(IFileService fileService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _fileService = fileService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<FileInfoDto> Handle(UploadFileRequest request, CancellationToken cancellationToken)
        {
            var file = await _fileService.Create(_mapper.Map<FileCreationData>(request));
            await _unitOfWork.Commit();
            return _mapper.Map<FileInfoDto>(file);
        }
    }
}