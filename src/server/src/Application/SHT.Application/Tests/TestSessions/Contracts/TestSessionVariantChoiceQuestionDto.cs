using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using SHT.Common.Utils;
using SHT.Domain.Models.TestSessions.Variants.Questions;

namespace SHT.Application.Tests.TestSessions.Contracts
{
    public class TestSessionVariantChoiceQuestionDto
    {
        public static readonly Expression<Func<TestSessionVariantChoiceQuestion, TestSessionVariantChoiceQuestionDto>> Selector =
            ExpressionUtils.Expand<TestSessionVariantChoiceQuestion, TestSessionVariantChoiceQuestionDto>(
                e => new TestSessionVariantChoiceQuestionDto
                {
                    Id = e.Id,
                    QuestionText = e.QuestionText,
                    Options = e.Options
                        .Select(q => TestSessionVariantChoiceQuestionOptionDto.Selector.Invoke(q))
                        .ToArray(),
                });

        public Guid Id { get; set; }

        public string QuestionText { get; set; }

        public IReadOnlyCollection<TestSessionVariantChoiceQuestionOptionDto> Options { get; set; } =
            new List<TestSessionVariantChoiceQuestionOptionDto>();
    }
}