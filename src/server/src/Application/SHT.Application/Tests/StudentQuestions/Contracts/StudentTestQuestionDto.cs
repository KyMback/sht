using System;
using System.Linq.Expressions;
using SHT.Application.Common;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.TestSessions.Students;

namespace SHT.Application.Tests.StudentQuestions.Contracts
{
    [ApiDataContract]
    public class StudentTestQuestionDto
    {
        public static readonly Expression<Func<StudentQuestion, StudentTestQuestionDto>> Selector =
            question => new StudentTestQuestionDto
            {
                Answer = question.Answer,
                Id = question.Id,
                Number = question.Number,
                Text = question.Text,
                Type = question.Type,
                StudentTestSessionId = question.StudentTestSessionId,
                IsAnswered = !string.IsNullOrWhiteSpace(question.Answer),
            };

        public Guid Id { get; set; }

        public string Text { get; set; }

        public string Number { get; set; }

        public string Answer { get; set; }

        public bool IsAnswered { get; set; }

        public Guid StudentTestSessionId { get; set; }

        public QuestionType Type { get; set; }
    }
}