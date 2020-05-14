using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using SHT.Application.Common;
using SHT.Application.Tests.TestSessions.Contracts.Assessments;
using SHT.Common.Utils;
using SHT.Domain.Models.TestSessions;

namespace SHT.Application.Tests.TestSessions.Contracts
{
    [ApiDataContract]
    public class TestSessionDto
    {
        public static readonly Expression<Func<TestSession, TestSessionDto>> Selector =
            ExpressionUtils.Expand<TestSession, TestSessionDto>(session =>
                new TestSessionDto
                {
                    Id = session.Id,
                    Name = session.Name,
                    State = session.State,
                    StudentsIds = session.StudentTestSessions.Select(e => e.StudentId).ToArray(),
                    TestVariants = session.Variants
                        .Select(e => TestSessionVariantDto.Selector.Invoke(e))
                        .OrderBy(e => e.Name)
                        .ToArray(),
                    CreatedAt = session.CreatedAt,
                    Assessment = AssessmentDto.Selector.Invoke(session.Assessment),
                });

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public IReadOnlyCollection<Guid> StudentsIds { get; set; } = new List<Guid>();

        public IReadOnlyCollection<TestSessionVariantDto> TestVariants { get; set; } = new List<TestSessionVariantDto>();

        public AssessmentDto Assessment { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}