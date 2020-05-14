using System;
using System.Collections.Generic;
using SHT.Domain.Models.Common;
using SHT.Domain.Models.TestSessions.Assessments;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Domain.Models.TestSessions.Variants;
using SHT.Infrastructure.Common.StateMachine.Core;

namespace SHT.Domain.Models.TestSessions
{
    public class TestSession : BaseEntity, IHasState, IHasCreatedAt
    {
        public string Name { get; set; }

        public Guid InstructorId { get; set; }

        /// <summary>
        /// Gets or sets current test session state <see cref="TestSessionState"/>
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets students which can participate in this test session
        /// </summary>
        public virtual IList<StudentTestSession> StudentTestSessions { get; set; } = new List<StudentTestSession>();

        /// <summary>
        /// Gets or sets test variants which will be used in this test session
        /// </summary>
        public virtual IList<TestSessionVariant> Variants { get; set; } = new List<TestSessionVariant>();

        /// <summary>
        /// Gets or sets assessment for this test session
        /// </summary>
        public virtual Assessment Assessment { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}