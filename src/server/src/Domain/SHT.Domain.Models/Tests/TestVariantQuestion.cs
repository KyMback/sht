using System;

namespace SHT.Domain.Models.Tests
{
    public class TestVariantQuestion : BaseEntity
    {
        public Guid TestVariantId { get; set; }

        public virtual TestVariant TestVariant { get; set; }

        public string Text { get; set; }

        public string Number { get; set; }

        public QuestionType Type { get; set; }
    }
}