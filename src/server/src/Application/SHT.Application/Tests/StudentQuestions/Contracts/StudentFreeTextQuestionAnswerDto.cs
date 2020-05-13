using System;
using System.Linq.Expressions;
using SHT.Domain.Models.TestSessions.Students.Answers;

namespace SHT.Application.Tests.StudentQuestions.Contracts
{
    public class StudentFreeTextQuestionAnswerDto
    {
        public static readonly Expression<Func<StudentFreeTextQuestionAnswer, StudentFreeTextQuestionAnswerDto>> Selector =
            answer => new StudentFreeTextQuestionAnswerDto
            {
                Answer = answer.Answer,
            };

        public string Answer { get; set; }
    }
}