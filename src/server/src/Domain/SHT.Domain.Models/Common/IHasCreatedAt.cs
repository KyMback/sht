using System;

namespace SHT.Domain.Models.Common
{
    public interface IHasCreatedAt
    {
        DateTime CreatedAt { get; set; }
    }
}