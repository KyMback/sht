namespace SHT.Domain.Models.TestSessions.Variants.Questions
{
    public class TestSessionVariantFreeTextQuestion : BaseEntity
    {
        public string QuestionText { get; set; }

        public string KeyWords { get; set; }
    }
}