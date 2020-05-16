using System;
using System.Collections.Generic;
using SHT.Domain.Models.TestSessions.Variants;
using SHT.Infrastructure.Common.StateMachine.Core;

namespace SHT.Domain.Models.TestSessions.Students
{
    public class StudentTestSession : BaseEntity, IHasState
    {
        public Guid StudentId { get; set; }

        public Guid TestSessionId { get; set; }

        public virtual TestSession TestSession { get; set; }

        public Guid? TestVariantId { get; set; }

        public virtual TestSessionVariant Variant { get; set; }

        /// <summary>
        /// Gets or sets current state of student test session
        /// <see cref="StudentTestSessionState"/> for details
        /// </summary>
        public string State { get; set; }

        public virtual IList<StudentTestSessionQuestion> Questions { get; set; } =
            new List<StudentTestSessionQuestion>();
    }
}