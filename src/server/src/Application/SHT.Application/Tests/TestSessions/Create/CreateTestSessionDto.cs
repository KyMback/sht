using System;
using System.Collections.Generic;
using SHT.Application.Core;

namespace SHT.Application.Tests.TestSessions.Create
{
    [ApiDataContract]
    public class CreateTestSessionDto
    {
        public string Name { get; set; }

        public IReadOnlyCollection<Guid> StudentsIds { get; set; }

        public IReadOnlyCollection<Guid> TestVariantsIds { get; set; }
    }
}