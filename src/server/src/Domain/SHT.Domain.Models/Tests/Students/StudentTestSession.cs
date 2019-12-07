using System;
using System.Collections.Generic;
using SHT.Domain.Models.Common;

namespace SHT.Domain.Models.Tests.Students
{
    public class StudentTestSession : BaseEntity, IHasState
    {
        public Guid StudentId { get; set; }

        public Guid TestSessionId { get; set; }

        public virtual TestSession TestSession { get; set; }

        public string State { get; set; }

        public string TestVariant { get; set; }

        public virtual IList<StudentQuestion> Questions { get; set; } = new List<StudentQuestion>();
    }
}