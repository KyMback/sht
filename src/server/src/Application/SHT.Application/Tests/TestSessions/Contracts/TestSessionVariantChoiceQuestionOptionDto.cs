using System;
using System.Linq.Expressions;
using SHT.Common.Utils;
using SHT.Domain.Models.TestSessions.Variants.Questions;

namespace SHT.Application.Tests.TestSessions.Contracts
{
    public class TestSessionVariantChoiceQuestionOptionDto
    {
        public static readonly Expression<Func<TestSessionVariantChoiceQuestionOption, TestSessionVariantChoiceQuestionOptionDto>> Selector =
            ExpressionUtils.Expand<TestSessionVariantChoiceQuestionOption, TestSessionVariantChoiceQuestionOptionDto>(
                e => new TestSessionVariantChoiceQuestionOptionDto
                {
                    Id = e.Id,
                    QuestionId = e.QuestionId,
                    IsCorrect = e.IsCorrect,
                    Text = e.Text,
                });

        public Guid Id { get; set; }

        public Guid QuestionId { get; set; }

        public string Text { get; set; }

        public bool IsCorrect { get; set; }
    }
}