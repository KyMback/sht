using System;
using SHT.Domain.Models.Tests;

namespace SHT.Domain.Models.TestSessions.Variants.Questions
{
    public class TestSessionVariantQuestion : BaseEntity
    {
        public int? Order { get; set; }

        public string Name { get; set; }

        public QuestionType Type { get; set; }

        public Guid TestSessionVariantId { get; set; }

        public Guid? SourceQuestionId { get; set; }

        public virtual TestSessionVariantFreeTextQuestion FreeTextQuestion { get; set; }

        public virtual TestSessionVariantChoiceQuestion ChoiceQuestion { get; set; }
    }
}