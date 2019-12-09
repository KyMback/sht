using System;
using SHT.Application.Common;
using SHT.Domain.Models.Tests;

namespace SHT.Application.Tests.StudentQuestions.Get
{
    [ApiDataContract]
    public class StudentQuestionDto
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public string Number { get; set; }

        public string Answer { get; set; }

        public QuestionType Type { get; set; }
    }
}