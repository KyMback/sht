using System;

namespace SHT.Domain.Models.Common
{
    public interface IHasModifiedAt
    {
        DateTime ModifiedAt { get; set; }
    }
}