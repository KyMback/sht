using System;
using System.Linq.Expressions;
using SHT.Common.Utils;
using SHT.Domain.Models.TestSessions.Variants.Questions;

namespace SHT.Application.Tests.StudentQuestions.Contracts
{
    public class StudentChoiceQuestionOptionDto
    {
        public static readonly Expression<Func<TestSessionVariantChoiceQuestionOption, StudentChoiceQuestionOptionDto>> Selector =
            ExpressionUtils.Expand<TestSessionVariantChoiceQuestionOption, StudentChoiceQuestionOptionDto>(
                e => new StudentChoiceQuestionOptionDto
                {
                    Id = e.Id,
                    QuestionId = e.QuestionId,
                    Text = e.Text,
                });

        public Guid Id { get; set; }

        public Guid QuestionId { get; set; }

        public string Text { get; set; }
    }
}