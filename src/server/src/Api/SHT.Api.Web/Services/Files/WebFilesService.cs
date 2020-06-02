using System;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SHT.Application.Files.Contracts;
using SHT.Application.Files.Download;
using SHT.Application.Files.Upload;

namespace SHT.Api.Web.Services.Files
{
    internal class WebFilesService : IWebFilesService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WebFilesService(
            IMapper mapper,
            IMediator mediator,
            IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<FileInfoDto> Save(UploadFileData data)
        {
            var request = _mapper.Map<UploadFileRequest>(data);
            return _mediator.Send(request);
        }

        public async Task<FileStreamResult> Download(Guid fileId)
        {
            DownloadFileDto file = await _mediator.Send(new DownloadFileRequest(fileId));

            var stream = await file.StreamAccessor();
            var result = new FileStreamResult(stream, file.ContentType);
            var disposition = new ContentDisposition
            {
                Inline = true,
                // Because can't escape 2 spaces in name with russian symbols
                FileName = Uri.EscapeDataString(file.FileName),
                Size = stream.Length,
            };

            _httpContextAccessor.HttpContext.Response.Headers.Add(
                HeaderNames.ContentDisposition,
                disposition.ToString());

            return result;
        }
    }
}