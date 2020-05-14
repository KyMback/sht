using System;
using System.Collections.Generic;

namespace SHT.Domain.Models.TestSessions.Assessments
{
    public class Assessment : BaseEntity
    {
        public virtual TestSession TestSession { get; set; }

        public Guid TestSessionId { get; set; }

        public virtual IList<QuestionAnswerAssessment> QuestionAnswerAssessments { get; set; } =
            new List<QuestionAnswerAssessment>();

        public virtual IList<AnswersAssessmentQuestion> AnswersAssessmentQuestions { get; set; } =
            new List<AnswersAssessmentQuestion>();
    }
}