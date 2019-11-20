using System;

namespace SHT.Domain.Models.Common
{
    public interface IHasCreatedBy
    {
        Guid CreatedById { get; set; }
    }
}