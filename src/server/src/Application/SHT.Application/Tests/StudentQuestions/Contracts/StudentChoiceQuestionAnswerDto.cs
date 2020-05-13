using System;
using System.Linq.Expressions;
using SHT.Domain.Models.TestSessions.Students.Answers;

namespace SHT.Application.Tests.StudentQuestions.Contracts
{
    public class StudentChoiceQuestionAnswerDto
    {
        public static readonly Expression<Func<StudentChoiceQuestionAnswer, StudentChoiceQuestionAnswerDto>> Selector =
            answer => new StudentChoiceQuestionAnswerDto
            {
                OptionId = answer.OptionId,
            };

        public Guid OptionId { get; set; }
    }
}