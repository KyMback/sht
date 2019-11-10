using System;

namespace SHT.Domain.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public bool IsNew => Id == default;
    }
}