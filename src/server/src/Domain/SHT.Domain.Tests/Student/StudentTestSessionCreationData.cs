using System;

namespace SHT.Domain.Services.Student
{
    public class StudentTestSessionCreationData
    {
        public Guid StudentId { get; set; }

        public Guid TestSessionId { get; set; }
    }
}