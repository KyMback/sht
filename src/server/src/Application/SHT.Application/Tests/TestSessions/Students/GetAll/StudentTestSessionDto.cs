using System;
using SHT.Application.Common;

namespace SHT.Application.Tests.TestSessions.Students.GetAll
{
    [ApiDataContract]
    public class StudentTestSessionDto
    {
        public Guid Id { get; set; }

        public string State { get; set; }

        public string Name { get; set; }

        public string TestVariant { get; set; }
    }
}