using System;
using System.IO;

namespace SHT.Domain.Common.Files
{
    public class FileCreationData
    {
        public string ContentType { get; set; }

        public long SizeBytes { get; set; }

        public string FileName { get; set; }

        public Func<Stream> StreamAccessor { get; set; }
    }
}