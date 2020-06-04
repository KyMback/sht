using System;

namespace SHT.Domain.Models.Questions
{
    public class QuestionTemplateImage
    {
        public Guid QuestionTemplateId { get; set; }

        public Guid FileId { get; set; }
    }
}