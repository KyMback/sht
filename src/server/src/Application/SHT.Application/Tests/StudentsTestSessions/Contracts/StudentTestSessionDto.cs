using System;
using System.Linq.Expressions;
using SHT.Application.Common;
using SHT.Domain.Models.Tests.Students;

namespace SHT.Application.Tests.StudentsTestSessions.Contracts
{
    [ApiDataContract]
    public class StudentTestSessionDto
    {
        public static readonly Expression<Func<StudentTestSession, StudentTestSessionDto>> Selector =
            session => new StudentTestSessionDto
            {
                Id = session.Id,
                State = session.State,
                Name = session.TestSession.Name,
                TestVariant = session.TestVariant,
                CreatedAt = session.TestSession.CreatedAt,
            };

        public Guid Id { get; set; }

        public string State { get; set; }

        public string Name { get; set; }

        public string TestVariant { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}