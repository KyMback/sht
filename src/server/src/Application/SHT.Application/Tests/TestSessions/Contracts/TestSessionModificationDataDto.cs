using System;
using System.Collections.Generic;
using SHT.Application.Common;

namespace SHT.Application.Tests.TestSessions.Contracts
{
    [ApiDataContract]
    public class TestSessionModificationDataDto
    {
        public string Name { get; set; }

        public IReadOnlyCollection<Guid> StudentsIds { get; set; }

        public IReadOnlyCollection<TestSessionVariantDataDto> TestVariants { get; set; }
    }
}