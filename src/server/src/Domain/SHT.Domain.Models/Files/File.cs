using System;
using SHT.Domain.Models.Common;
using SHT.Infrastructure.FileStorage;

namespace SHT.Domain.Models.Files
{
    public class File : BaseEntity, IHasCreatedBy, IHasCreatedAt
    {
        public FileStorageType StorageType { get; set; }

        public string Reference { get; set; }

        public string ContentType { get; set; }

        public string OriginalName { get; set; }

        public long SizeBytes { get; set; }

        public Guid CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}