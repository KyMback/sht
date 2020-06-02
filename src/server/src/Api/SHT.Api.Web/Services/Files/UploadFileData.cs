using Microsoft.AspNetCore.Http;

namespace SHT.Api.Web.Services.Files
{
    public class UploadFileData
    {
        public IFormFile File { get; set; }
    }
}