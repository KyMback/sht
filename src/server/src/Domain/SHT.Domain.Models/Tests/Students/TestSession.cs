using System;
using System.Collections.Generic;
using SHT.Domain.Models.Common;

namespace SHT.Domain.Models.Tests.Students
{
    public class TestSession : BaseEntity, IHasState
    {
        public string Name { get; set; }

        public Guid InstructorId { get; set; }

        public string State { get; set; }

        // Students which can participate in this test session
        public virtual IList<StudentTestSession> StudentTestSessions { get; set; }

        // Test variants which will be used in this test session
        public virtual IList<TestSessionTestVariant> TestSessionTestVariants { get; set; }
    }
}