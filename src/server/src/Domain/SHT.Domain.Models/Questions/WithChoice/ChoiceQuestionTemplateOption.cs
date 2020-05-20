using System;

namespace SHT.Domain.Models.Questions.WithChoice
{
    public class ChoiceQuestionTemplateOption : BaseEntity
    {
        public Guid ChoiceQuestionTemplateId { get; set; }

        public string Text { get; set; }

        public bool IsCorrect { get; set;  }

        public bool IsRequired { get; set; }
    }
}