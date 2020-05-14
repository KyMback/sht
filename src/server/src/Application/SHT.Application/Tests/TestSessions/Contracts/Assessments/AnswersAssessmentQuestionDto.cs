using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SHT.Common.Utils;
using SHT.Domain.Models.TestSessions.Assessments;

namespace SHT.Application.Tests.TestSessions.Contracts.Assessments
{
    public class AnswersAssessmentQuestionDto
    {
        public static readonly Expression<Func<AnswersAssessmentQuestion, AnswersAssessmentQuestionDto>> Selector =
            ExpressionUtils.Expand<AnswersAssessmentQuestion, AnswersAssessmentQuestionDto>(question =>
                new AnswersAssessmentQuestionDto
                {
                    Id = question.Id,
                    QuestionText = question.QuestionText,
                    Questions = question.Questions.Select(e => e.TestSessionVariantQuestionId).ToArray(),
                });

        public Guid Id { get; set; }

        public string QuestionText { get; set; }

        public IReadOnlyCollection<Guid> Questions { get; set; }
    }
}