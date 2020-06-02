using System;
using MediatR;
using SHT.Application.Files.Contracts;

namespace SHT.Application.Files.Download
{
    public class DownloadFileRequest : IRequest<DownloadFileDto>
    {
        public DownloadFileRequest(Guid fileId)
        {
            FileId = fileId;
        }

        public Guid FileId { get; }
    }
}
