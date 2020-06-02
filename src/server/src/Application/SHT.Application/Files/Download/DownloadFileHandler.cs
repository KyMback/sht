using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Files.Contracts;
using SHT.Domain.Common.Files;
using SHT.Infrastructure.Common.ExecutionContext;
using SHT.Infrastructure.DataAccess.Abstractions;
using SHT.Infrastructure.FileStorage;

namespace SHT.Application.Files.Download
{
    [UsedImplicitly]
    internal class DownloadFileHandler : IRequestHandler<DownloadFileRequest, DownloadFileDto>
    {
        private readonly IExecutionContextService _executionContextService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFilesStorage _filesStorage;

        public DownloadFileHandler(
            IExecutionContextService executionContextService,
            IUnitOfWork unitOfWork,
            IFilesStorage filesStorage)
        {
            _executionContextService = executionContextService;
            _unitOfWork = unitOfWork;
            _filesStorage = filesStorage;
        }

        public async Task<DownloadFileDto> Handle(DownloadFileRequest request, CancellationToken cancellationToken)
        {
            var queryParams = new FileQueryParameters(
                id: request.FileId,
                createdById: _executionContextService.GetCurrentUserId());

            var fileInfo = await _unitOfWork.GetSingle(
                queryParams,
                f => new
                {
                    f.Reference,
                    f.ContentType,
                    f.OriginalName,
                });

            Func<Task<Stream>> streamAccessor = _filesStorage.Get(fileInfo.Reference);

            return new DownloadFileDto
            {
                ContentType = fileInfo.ContentType,
                FileName = fileInfo.OriginalName,
                StreamAccessor = streamAccessor,
            };
        }
    }
}
