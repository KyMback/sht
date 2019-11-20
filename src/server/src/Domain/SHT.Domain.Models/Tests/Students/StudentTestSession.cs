using System;
using System.Collections.Generic;
using SHT.Domain.Models.Common;

namespace SHT.Domain.Models.Tests.Students
{
    public class StudentTestSession : BaseEntity, IHasState
    {
        public Guid StudentId { get; set; }

        public Guid TestSessionId { get; set; }

        public string State { get; set; }

        public string TestNumber { get; set; }

        public virtual IList<StudentQuestion> Questions { get; set; } = new List<StudentQuestion>();
    }
}