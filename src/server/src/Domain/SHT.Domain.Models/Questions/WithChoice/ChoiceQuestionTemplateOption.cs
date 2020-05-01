namespace SHT.Domain.Models.Questions.WithChoice
{
    public class ChoiceQuestionTemplateOption : BaseEntity
    {
        public string Text { get; set; }

        public bool IsCorrect { get; set;  }
    }
}