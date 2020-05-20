using System;

namespace SHT.Domain.Models.TestSessions.Variants.Questions
{
    public class TestSessionVariantChoiceQuestionOption : BaseEntity
    {
        public string Text { get; set; }

        public Guid QuestionId { get; set; }

        public bool IsCorrect { get; set;  }

        public bool IsRequired { get; set;  }
    }
}