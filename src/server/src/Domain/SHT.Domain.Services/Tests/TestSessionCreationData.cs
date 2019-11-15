using System;
using System.Collections.Generic;

namespace SHT.Domain.Services.Tests
{
    public class TestSessionCreationData
    {
        public string Name { get; set; }

        public IReadOnlyCollection<Guid> StudentsIds { get; set; }

        public IReadOnlyCollection<Guid> TestVariantsIds { get; set; }

        public Guid InstructorId { get; set; }
    }
}