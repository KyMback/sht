using System;

namespace SHT.Domain.Models.Questions
{
    public class QuestionTemplateTag
    {
        public Guid QuestionTemplateId { get; set; }

        public Guid TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}