using System;

namespace SHT.Domain.Services.Student.Questions
{
    public class StudentQuestionCreationData
    {
        public Guid StudentTestSessionId { get; set; }

        public Guid TestVariantId { get; set; }
    }
}