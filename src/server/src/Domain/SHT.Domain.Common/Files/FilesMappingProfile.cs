using AutoMapper;
using JetBrains.Annotations;
using SHT.Domain.Models.Files;
using SHT.Infrastructure.Common.Extensions;

namespace SHT.Domain.Common.Files
{
    [UsedImplicitly]
    internal class FilesMappingProfile : Profile
    {
        public FilesMappingProfile()
        {
            CreateMap<FileCreationData, File>()
                .Map(d => d.ContentType, s => s.ContentType)
                .Map(d => d.OriginalName, s => s.FileName)
                .Map(d => d.SizeBytes, s => s.SizeBytes)
                .IgnoreAllOther();
        }
    }
}