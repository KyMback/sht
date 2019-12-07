using System;
using System.Collections.Generic;
using SHT.Domain.Models.Tests;

namespace SHT.Domain.Services.Tests
{
    public class StudentTestSessionLinkData
    {
        public StudentTestSessionLinkData(TestSession testSession, IReadOnlyCollection<Guid> studentIds)
        {
            TestSession = testSession;
            StudentIds = studentIds;
        }

        public TestSession TestSession { get; set; }

        public IReadOnlyCollection<Guid> StudentIds { get; set; }
    }
}