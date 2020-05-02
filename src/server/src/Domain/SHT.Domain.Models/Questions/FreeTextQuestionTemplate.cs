using System;

namespace SHT.Domain.Models.Questions
{
    public class FreeTextQuestionTemplate : BaseEntity
    {
        public Guid QuestionTemplateId { get; set; }

        public string Question { get; set; }
    }
}