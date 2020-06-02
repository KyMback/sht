using System;
using SHT.Application.Common;

namespace SHT.Application.Files.Contracts
{
    [ApiDataContract]
    public class FileInfoDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }
    }
}