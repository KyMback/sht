using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using SHT.Application.Tests.StudentQuestions.Contracts;
using SHT.Common.Utils;
using SHT.Domain.Models.TestSessions.Students;

namespace SHT.Application.Tests.StudentsTestSessions.Contracts
{
    public class StudentTestSessionDto
    {
        public static readonly Expression<Func<StudentTestSession, StudentTestSessionDto>> Selector =
            ExpressionUtils.Expand<StudentTestSession, StudentTestSessionDto>(
                session => new StudentTestSessionDto
                {
                    Id = session.Id,
                    State = session.State,
                    Name = session.TestSession.Name,
                    TestVariant = session.Variant.Name,
                    CreatedAt = session.TestSession.CreatedAt,
                    Questions = session.Questions.Select(e => StudentTestQuestionDto.Selector.Invoke(e)).ToArray(),
                });

        public Guid Id { get; set; }

        public string State { get; set; }

        public string Name { get; set; }

        public string TestVariant { get; set; }

        public DateTime CreatedAt { get; set; }

        public IReadOnlyCollection<StudentTestQuestionDto> Questions { get; set; }
    }
}