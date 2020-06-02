using AutoMapper;
using Hangfire.PostgreSql.Properties;
using SHT.Application.Files.Upload;
using SHT.Infrastructure.Common.Extensions;

namespace SHT.Api.Web.Services.Files
{
    [UsedImplicitly]
    internal class FilesMappingProfile : Profile
    {
        public FilesMappingProfile()
        {
            CreateMap<UploadFileData, UploadFileRequest>()
                .Map(x => x.ContentType, x => x.File.ContentType)
                .Map(x => x.FileName, x => x.File.FileName)
                .Map(x => x.SizeBytes, x => x.File.Length)
                .AfterMap((s, d) => d.StreamAccessor = s.File.OpenReadStream)
                .IgnoreAllOther();
        }
    }
}