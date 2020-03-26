using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using SHT.Application.Common;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.Tests.Students;

namespace SHT.Application.Tests.StudentsTestSessions.Contracts
{
    [ApiDataContract]
    public class StudentTestQuestionListItemDto
    {
        public static readonly Expression<Func<StudentQuestion, StudentTestQuestionListItemDto>> Selector =
            question => new StudentTestQuestionListItemDto
            {
                Id = question.Id,
                Number = question.Number,
                Type = question.Type,
                StudentTestSessionId = question.StudentTestSessionId,
                IsAnswered = !string.IsNullOrWhiteSpace(question.Answer),
            };

        public Guid Id { get; set; }

        [Required]
        public string Number { get; set; }

        public bool IsAnswered { get; set; }

        public QuestionType Type { get; set; }

        public Guid StudentTestSessionId { get; set; }
    }
}