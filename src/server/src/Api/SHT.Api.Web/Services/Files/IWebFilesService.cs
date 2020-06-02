using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SHT.Application.Files.Contracts;

namespace SHT.Api.Web.Services.Files
{
    public interface IWebFilesService
    {
        Task<FileInfoDto> Save(UploadFileData data);

        Task<FileStreamResult> Download(Guid fileId);
    }
}