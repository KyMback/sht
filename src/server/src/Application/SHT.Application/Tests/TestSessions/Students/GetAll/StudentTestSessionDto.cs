using System;
using SHT.Application.Common;

namespace SHT.Application.Tests.TestSessions.Students.GetAll
{
    [ApiDataContract]
    public class StudentTestSessionDto
    {
        public Guid Id { get; set; }

        public Guid TestSessionId { get; set; }

        public string State { get; set; }

        public string TestNumber { get; set; }
    }
}