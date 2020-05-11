using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using SHT.Common.Utils;
using SHT.Domain.Models.TestSessions.Variants;

namespace SHT.Application.Tests.TestSessions.Contracts
{
    public class TestSessionVariantDto
    {
        public static readonly Expression<Func<TestSessionVariant, TestSessionVariantDto>> Selector =
            ExpressionUtils.Expand<TestSessionVariant, TestSessionVariantDto>(
                e => new TestSessionVariantDto
                {
                    Id = e.Id,
                    TestSessionId = e.TestSessionId,
                    Name = e.Name,
                    IsRandomOrder = e.IsRandomOrder,
                    Questions = e.Questions
                        .Select(q => TestSessionVariantQuestionDto.Selector.Invoke(q))
                        .ToArray(),
                });

        public Guid Id { get; set; }

        public Guid TestSessionId { get; set; }

        public string Name { get; set; }

        public bool IsRandomOrder { get; set; }

        public IReadOnlyCollection<TestSessionVariantQuestionDto> Questions { get; set; } =
            new List<TestSessionVariantQuestionDto>();
    }
}