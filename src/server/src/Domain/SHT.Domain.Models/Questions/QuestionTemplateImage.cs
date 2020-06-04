using System;
using SHT.Domain.Models.Files;

namespace SHT.Domain.Models.Questions
{
    public class QuestionTemplateImage
    {
        public Guid QuestionTemplateId { get; set; }

        public Guid FileId { get; set; }

        public virtual File File { get; set; }
    }
}