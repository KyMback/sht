using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using SHT.Common.Utils;
using SHT.Domain.Models.TestSessions.Variants.Questions;

namespace SHT.Application.Tests.StudentQuestions.Contracts
{
    public class StudentChoiceQuestionDto
    {
        public static readonly Expression<Func<TestSessionVariantChoiceQuestion, StudentChoiceQuestionDto>> Selector =
            ExpressionUtils.Expand<TestSessionVariantChoiceQuestion, StudentChoiceQuestionDto>(
                e => new StudentChoiceQuestionDto
                {
                    Id = e.Id,
                    QuestionText = e.QuestionText,
                    Options = e.Options
                        .Select(q => StudentChoiceQuestionOptionDto.Selector.Invoke(q))
                        .ToArray(),
                });

        public Guid Id { get; set; }

        public string QuestionText { get; set; }

        public IReadOnlyCollection<StudentChoiceQuestionOptionDto> Options { get; set; } =
            new List<StudentChoiceQuestionOptionDto>();
    }
}