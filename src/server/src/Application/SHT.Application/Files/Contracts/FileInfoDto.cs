using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using SHT.Application.Common;
using SHT.Common.Utils;
using SHT.Domain.Models.Files;

namespace SHT.Application.Files.Contracts
{
    [ApiDataContract]
    public class FileInfoDto
    {
        public static readonly Expression<Func<File, FileInfoDto>> Selector =
            ExpressionUtils.Expand<File, FileInfoDto>(file =>
                new FileInfoDto
                {
                    Id = file.Id,
                    Name = file.OriginalName,
                    ContentType = file.ContentType,
                });

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ContentType { get; set; }
    }
}