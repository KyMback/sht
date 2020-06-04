using System;
using SHT.Domain.Models.Files;

namespace SHT.Domain.Models.TestSessions.Variants.Questions
{
    public class TestSessionVariantQuestionImage
    {
        public Guid TestSessionVariantQuestionId { get; set; }

        public Guid FileId { get; set; }

        public virtual File File { get; set; }
    }
}