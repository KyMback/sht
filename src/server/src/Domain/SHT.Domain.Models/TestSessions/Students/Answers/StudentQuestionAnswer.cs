using System;
using System.Collections.Generic;

namespace SHT.Domain.Models.TestSessions.Students.Answers
{
    public class StudentQuestionAnswer : BaseEntity
    {
        public Guid QuestionId { get; set; }

        public bool IsAnswered { get; set; }

        public virtual StudentFreeTextQuestionAnswer FreeTextAnswer { get; set; }

        public virtual IList<StudentChoiceQuestionAnswer> ChoiceQuestionAnswers { get; set; } =
            new List<StudentChoiceQuestionAnswer>();
    }
}