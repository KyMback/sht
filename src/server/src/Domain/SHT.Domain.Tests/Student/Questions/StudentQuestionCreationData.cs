using System;

namespace SHT.Domain.Services.Tests.Student.Questions
{
    public class StudentQuestionCreationData
    {
        public Guid StudentTestSessionId { get; set; }

        public Guid TestVariantId { get; set; }
    }
}