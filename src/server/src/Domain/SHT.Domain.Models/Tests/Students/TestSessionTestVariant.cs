using System;

namespace SHT.Domain.Models.Tests.Students
{
    public class TestSessionTestVariant : BaseEntity
    {
        public Guid TestVariantId { get; set; }

        public Guid TestSessionId { get; set; }
    }
}