using System;
using SHT.Domain.Models.TestSessions.Students.Answers;
using SHT.Domain.Models.TestSessions.Variants.Questions;

namespace SHT.Domain.Models.TestSessions.Students
{
    public class StudentTestSessionQuestion : BaseEntity
    {
        public int Order { get; set; }

        public string Name { get; set; }

        public virtual TestSessionVariantQuestion Question { get; set; }

        public Guid QuestionId { get; set; }

        public virtual StudentTestSession StudentTestSession { get; set; }

        public Guid StudentTestSessionId { get; set; }

        public virtual StudentQuestionAnswer Answer { get; set; }
    }
}