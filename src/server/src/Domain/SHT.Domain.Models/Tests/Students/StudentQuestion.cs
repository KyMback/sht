using System;

namespace SHT.Domain.Models.Tests.Students
{
    public class StudentQuestion : BaseEntity
    {
        public string Text { get; set; }

        public int Number { get; set; }

        public string Answer { get; set; }

        public QuestionType Type { get; set; }

        public double Grade { get; set; }

        public string State { get; set; }

        public Guid StudentTestSessionId { get; set; }
    }
}