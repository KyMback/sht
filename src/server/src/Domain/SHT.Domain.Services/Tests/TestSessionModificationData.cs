using System;
using System.Collections.Generic;

namespace SHT.Domain.Services.Tests
{
    public class TestSessionModificationData
    {
        public string Name { get; set; }

        public IReadOnlyCollection<Guid> StudentsIds { get; set; }

        public IReadOnlyCollection<TestSessionVariantData> TestVariants { get; set; }
    }
}