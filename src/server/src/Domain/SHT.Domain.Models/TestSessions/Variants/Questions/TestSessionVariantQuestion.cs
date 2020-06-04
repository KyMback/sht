using System;
using System.Collections.Generic;
using SHT.Domain.Models.Tests;

namespace SHT.Domain.Models.TestSessions.Variants.Questions
{
    public class TestSessionVariantQuestion : BaseEntity
    {
        public int? Order { get; set; }

        public string Name { get; set; }

        public QuestionType Type { get; set; }

        public Guid TestSessionVariantId { get; set; }

        public virtual TestSessionVariant TestSessionVariant { get; set; }

        public Guid? SourceQuestionId { get; set; }

        public virtual IList<TestSessionVariantQuestionImage> Images { get; set; } =
            new List<TestSessionVariantQuestionImage>();

        public virtual TestSessionVariantFreeTextQuestion FreeTextQuestion { get; set; }

        public virtual TestSessionVariantChoiceQuestion ChoiceQuestion { get; set; }
    }
}