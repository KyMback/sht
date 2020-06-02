using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SHT.Api.Web.Constants;
using SHT.Api.Web.Services.Files;
using SHT.Application.Files.Contracts;

namespace SHT.Api.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IWebFilesService _webFilesService;

        public FilesController(IWebFilesService webFilesService)
        {
            _webFilesService = webFilesService;
        }

        [HttpPost]
        [RequestSizeLimit(ControllerActionsConstants.UploadFileRequestSizeLimitBytes)]
        public Task<FileInfoDto> UploadFiles([FromForm] UploadFileData data)
        {
            return _webFilesService.Save(data);
        }

        [HttpGet("{fileId}")]
        public Task<FileStreamResult> Download([FromRoute] Guid fileId)
        {
            return _webFilesService.Download(fileId);
        }
    }
}