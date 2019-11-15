using System;

namespace SHT.Domain.Models.Tests.Students
{
    public class StudentTestVariant : BaseEntity
    {
        public Guid StudentId { get; set; }

        public Guid TestSessionId { get; set; }

        public string State { get; set; }

        public int Number { get; set; }
    }
}