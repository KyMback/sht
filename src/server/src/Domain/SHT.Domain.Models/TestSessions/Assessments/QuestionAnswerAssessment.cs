using System;
using SHT.Domain.Models.TestSessions.Students.Answers;

namespace SHT.Domain.Models.TestSessions.Assessments
{
    public class QuestionAnswerAssessment : BaseEntity
    {
        public Guid AssessmentId { get; set; }

        /// <summary>
        /// Gets or sets id of <see cref="StudentQuestionAnswer"/>
        /// </summary>
        public Guid StudentQuestionAnswerId { get; set; }

        public virtual StudentQuestionAnswer StudentQuestionAnswer { get; set; }

        /// <remarks>
        /// Null if answer isn't rated
        /// </remarks>
        public double? Correctness { get; set; }
    }
}