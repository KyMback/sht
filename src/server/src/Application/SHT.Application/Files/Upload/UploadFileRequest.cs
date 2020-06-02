using System;
using System.IO;
using MediatR;
using SHT.Application.Files.Contracts;

namespace SHT.Application.Files.Upload
{
    public class UploadFileRequest : IRequest<FileInfoDto>
    {
        public string ContentType { get; set; }

        public int SizeBytes { get; set; }

        public string FileName { get; set; }

        public Func<Stream> StreamAccessor { get; set; }
    }
}