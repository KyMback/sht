using System;

namespace SHT.Domain.Models.Tests
{
    public class TestSessionTestVariant : BaseEntity
    {
        public string Name { get; set; }

        public Guid TestVariantId { get; set; }

        public virtual TestVariant TestVariant { get; set; }

        public Guid TestSessionId { get; set; }

        public virtual TestSession TestSession { get; set; }
    }
}