using System;
using System.Collections.Generic;
using SHT.Domain.Models.Common;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Domain.Models.TestSessions.Variants;

namespace SHT.Domain.Models.TestSessions
{
    public class TestSession : BaseEntity, IHasState, IHasCreatedAt
    {
        public string Name { get; set; }

        public Guid InstructorId { get; set; }

        public string State { get; set; }

        // Students which can participate in this test session
        public virtual IList<StudentTestSession> StudentTestSessions { get; set; } = new List<StudentTestSession>();

        // Test variants which will be used in this test session
        public virtual IList<TestSessionVariant> Variants { get; set; } = new List<TestSessionVariant>();

        public DateTime CreatedAt { get; set; }
    }
}