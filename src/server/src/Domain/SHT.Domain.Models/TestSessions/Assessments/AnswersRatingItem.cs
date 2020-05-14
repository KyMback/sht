using System;
using SHT.Domain.Models.TestSessions.Students.Answers;

namespace SHT.Domain.Models.TestSessions.Assessments
{
    public class AnswersRatingItem : BaseEntity
    {
        public Guid AnswersRatingId { get; set; }

        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets id of <see cref="StudentQuestionAnswer"/>
        /// </summary>
        public Guid StudentQuestionAnswerId { get; set; }
    }
}