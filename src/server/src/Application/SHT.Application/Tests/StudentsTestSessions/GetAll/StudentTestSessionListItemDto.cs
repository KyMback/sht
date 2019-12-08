using System;
using SHT.Application.Common;

namespace SHT.Application.Tests.StudentsTestSessions.GetAll
{
    [ApiDataContract]
    public class StudentTestSessionListItemDto
    {
        public Guid Id { get; set; }

        public string State { get; set; }

        public string Name { get; set; }

        public string TestVariant { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}