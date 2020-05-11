using System.Collections.Generic;

namespace SHT.Domain.Models.TestSessions.Variants.Questions
{
    public class TestSessionVariantChoiceQuestion : BaseEntity
    {
        public string QuestionText { get; set; }

        public virtual IList<TestSessionVariantChoiceQuestionOption> Options { get; set; } =
            new List<TestSessionVariantChoiceQuestionOption>();
    }
}