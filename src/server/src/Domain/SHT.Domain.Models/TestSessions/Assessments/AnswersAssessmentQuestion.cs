using System;
using System.Collections.Generic;

namespace SHT.Domain.Models.TestSessions.Assessments
{
    public class AnswersAssessmentQuestion : BaseEntity
    {
        public Guid AssessmentId { get; set; }

        public string QuestionText { get; set; }

        public virtual IList<AnswersAssessmentQuestionTestSessionVariantQuestion> Questions { get; set; } =
            new List<AnswersAssessmentQuestionTestSessionVariantQuestion>();

        public virtual IList<AnswersRating> AnswersRatings { get; set; } =
            new List<AnswersRating>();
    }
}