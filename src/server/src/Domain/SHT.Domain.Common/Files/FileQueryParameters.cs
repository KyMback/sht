using System;
using SHT.Domain.Common.Core;
using SHT.Domain.Models.Files;

namespace SHT.Domain.Common.Files
{
    public class FileQueryParameters : BaseQueryParameters<File>
    {
        public FileQueryParameters(Guid? createdById = default, Guid? id = default)
        {
            CreatedById = createdById;
            Id = id;
        }

        public Guid? CreatedById { get; set; }

        public Guid? Id { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(Id, file => file.Id == Id.Value);
            FilterIfHasValue(CreatedById, file => file.CreatedById == CreatedById.Value);
        }
    }
}