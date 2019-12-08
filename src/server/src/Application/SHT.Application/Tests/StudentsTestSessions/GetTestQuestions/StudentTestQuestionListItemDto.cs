using System;
using System.ComponentModel.DataAnnotations;
using SHT.Application.Common;
using SHT.Domain.Models.Tests;

namespace SHT.Application.Tests.StudentsTestSessions.GetTestQuestions
{
    [ApiDataContract]
    public class StudentTestQuestionListItemDto
    {
        public Guid Id { get; set; }

        [Required]
        public string Number { get; set; }

        public bool IsAnswered { get; set; }

        public QuestionType Type { get; set; }
    }
}