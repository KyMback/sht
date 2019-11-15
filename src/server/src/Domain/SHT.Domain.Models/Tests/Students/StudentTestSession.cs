using System;

namespace SHT.Domain.Models.Tests.Students
{
    public class StudentTestSession : BaseEntity
    {
        public Guid StudentId { get; set; }

        public Guid TestSessionId { get; set; }
    }
}