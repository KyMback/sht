using System;
using System.Linq.Expressions;
using SHT.Common.Utils;
using SHT.Domain.Models.TestSessions.Variants.Questions;

namespace SHT.Application.Tests.TestSessions.Contracts
{
    public class TestSessionVariantFreeTextQuestionDto
    {
        public static readonly Expression<Func<TestSessionVariantFreeTextQuestion, TestSessionVariantFreeTextQuestionDto>> Selector =
            ExpressionUtils.Expand<TestSessionVariantFreeTextQuestion, TestSessionVariantFreeTextQuestionDto>(
                e => new TestSessionVariantFreeTextQuestionDto
                {
                    Id = e.Id,
                    QuestionText = e.QuestionText,
                });

        public Guid Id { get; set; }

        public string QuestionText { get; set; }
    }
}