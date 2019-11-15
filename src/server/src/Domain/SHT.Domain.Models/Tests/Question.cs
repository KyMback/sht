using System;

namespace SHT.Domain.Models.Tests
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }

        public int Number { get; set; }

        public QuestionType Type { get; set; }

        public Guid TestVariantId { get; set; }
    }
}