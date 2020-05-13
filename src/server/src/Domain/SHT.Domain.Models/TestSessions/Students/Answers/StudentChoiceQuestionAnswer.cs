using System;

namespace SHT.Domain.Models.TestSessions.Students.Answers
{
    public class StudentChoiceQuestionAnswer : BaseEntity
    {
        public Guid StudentQuestionAnswerId { get; set; }

        public Guid OptionId { get; set; }
    }
}