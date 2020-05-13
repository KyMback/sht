using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using SHT.Common.Utils;
using SHT.Domain.Models.TestSessions.Students.Answers;

namespace SHT.Application.Tests.StudentQuestions.Contracts
{
    public class StudentQuestionAnswerDto
    {
        public static readonly Expression<Func<StudentQuestionAnswer, StudentQuestionAnswerDto>> Selector =
            ExpressionUtils.Expand<StudentQuestionAnswer, StudentQuestionAnswerDto>(
                answer => new StudentQuestionAnswerDto
                {
                    FreeTextAnswer = StudentFreeTextQuestionAnswerDto.Selector.Invoke(answer.FreeTextAnswer),
                    ChoiceQuestionAnswers = answer
                        .ChoiceQuestionAnswers
                        .Select(e => StudentChoiceQuestionAnswerDto.Selector.Invoke(e))
                        .ToArray(),
                });

        public StudentFreeTextQuestionAnswerDto FreeTextAnswer { get; set; }

        public IReadOnlyCollection<StudentChoiceQuestionAnswerDto> ChoiceQuestionAnswers { get; set; }
    }
}