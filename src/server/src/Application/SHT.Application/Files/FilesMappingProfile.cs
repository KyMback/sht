using AutoMapper;
using JetBrains.Annotations;
using SHT.Application.Files.Contracts;
using SHT.Application.Files.Upload;
using SHT.Domain.Common.Files;
using SHT.Domain.Models.Files;
using SHT.Infrastructure.Common.Extensions;

namespace SHT.Application.Files
{
    [UsedImplicitly]
    internal class FilesMappingProfile : Profile
    {
        public FilesMappingProfile()
        {
            CreateMap<UploadFileRequest, FileCreationData>();

            CreateMap<File, FileInfoDto>()
                .Map(d => d.Id, s => s.Id)
                .Map(d => d.Name, s => s.OriginalName)
                .Map(d => d.ContentType, s => s.ContentType)
                .IgnoreAllOther();
        }
    }
}