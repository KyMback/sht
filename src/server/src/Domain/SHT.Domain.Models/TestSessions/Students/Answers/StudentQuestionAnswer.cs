using System;
using System.Collections.Generic;
using SHT.Domain.Models.Common;
using SHT.Domain.Models.TestSessions.Assessments;

namespace SHT.Domain.Models.TestSessions.Students.Answers
{
    public class StudentQuestionAnswer : BaseEntity, IHasModifiedAt
    {
        public virtual StudentTestSessionQuestion Question { get; set; }

        public Guid QuestionId { get; set; }

        public bool IsAnswered { get; set; }

        public virtual StudentFreeTextQuestionAnswer FreeTextAnswer { get; set; }

        public virtual IList<StudentChoiceQuestionAnswer> ChoiceQuestionAnswers { get; set; } =
            new List<StudentChoiceQuestionAnswer>();

        public virtual QuestionAnswerAssessment AnswerAssessment { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}