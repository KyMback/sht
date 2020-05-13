using System;
using System.Linq.Expressions;
using LinqKit;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Common.Utils;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.TestSessions.Students;

namespace SHT.Application.Tests.StudentQuestions.Contracts
{
    public class StudentTestQuestionDto
    {
        public static readonly Expression<Func<StudentTestSessionQuestion, StudentTestQuestionDto>> Selector =
            ExpressionUtils.Expand<StudentTestSessionQuestion, StudentTestQuestionDto>(
                question => new StudentTestQuestionDto
            {
                Id = question.Id,
                Order = question.Order,
                Type = question.Question.Type,
                StudentTestSessionId = question.StudentTestSessionId,
                IsAnswered = question.Answer != null,
                Answer = question.Answer != null ? StudentQuestionAnswerDto.Selector.Invoke(question.Answer) : null,
                FreeTextQuestion = question.Question.Type == QuestionType.FreeText
                    ? TestSessionVariantFreeTextQuestionDto.Selector.Invoke(question.Question.FreeTextQuestion)
                    : null,
                ChoiceQuestion = question.Question.Type == QuestionType.QuestionWithChoice
                    ? TestSessionVariantChoiceQuestionDto.Selector.Invoke(question.Question.ChoiceQuestion)
                    : null,
            });

        public Guid Id { get; set; }

        public int Order { get; set; }

        public bool IsAnswered { get; set; }

        public QuestionType Type { get; set; }

        public Guid StudentTestSessionId { get; set; }

        public StudentQuestionAnswerDto Answer { get; set; }

        public TestSessionVariantFreeTextQuestionDto FreeTextQuestion { get; set; }

        public TestSessionVariantChoiceQuestionDto ChoiceQuestion { get; set; }
    }
}