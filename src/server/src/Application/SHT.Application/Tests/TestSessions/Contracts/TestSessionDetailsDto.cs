using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using SHT.Application.Common;
using SHT.Common.Utils;
using SHT.Domain.Models.Tests;

namespace SHT.Application.Tests.TestSessions.Contracts
{
    [ApiDataContract]
    public class TestSessionDetailsDto
    {
        public static readonly Expression<Func<TestSession, TestSessionDetailsDto>> Selector =
            ExpressionUtils.Expand<TestSession, TestSessionDetailsDto>(session =>
                new TestSessionDetailsDto
                {
                    Id = session.Id,
                    Name = session.Name,
                    StudentsIds = session.StudentTestSessions.Select(e => e.StudentId).ToArray(),
                    TestVariants = session.TestSessionTestVariants.Select(e => TestSessionVariantDataDto.Selector.Invoke(e))
                        .ToArray(),
                });

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public IReadOnlyCollection<Guid> StudentsIds { get; set; }

        [Required]
        public IReadOnlyCollection<TestSessionVariantDataDto> TestVariants { get; set; }
    }
}