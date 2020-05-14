using System;
using System.Collections.Generic;

namespace SHT.Domain.Models.TestSessions.Assessments
{
    public class AnswersRating : BaseEntity
    {
        public virtual AnswersAssessmentQuestion AnswersAssessmentQuestion { get; set; }

        public Guid AnswersAssessmentQuestionId { get; set; }

        /// <summary>
        /// Gets or sets student id who adds rating
        /// </summary>
        public Guid StudentId { get; set; }

        public virtual IList<AnswersRatingItem> AnswersRatingItems { get; set; } =
            new List<AnswersRatingItem>();
    }
}