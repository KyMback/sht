using System;
using System.Collections.Generic;

namespace SHT.Application.Tests.TestSessions.Create
{
    public class CreateTestSessionDto
    {
        public string Name { get; set; }

        public IReadOnlyCollection<Guid> StudentsIds { get; set; }

        public IReadOnlyCollection<Guid> TestVariantsIds { get; set; }
    }
}