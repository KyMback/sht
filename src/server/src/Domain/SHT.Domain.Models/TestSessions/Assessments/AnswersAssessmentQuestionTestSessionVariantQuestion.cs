using System;
using SHT.Domain.Models.TestSessions.Variants.Questions;

namespace SHT.Domain.Models.TestSessions.Assessments
{
    public class AnswersAssessmentQuestionTestSessionVariantQuestion
    {
        public virtual TestSessionVariantQuestion TestSessionVariantQuestion { get; set; }

        public Guid TestSessionVariantQuestionId { get; set; }

        public Guid AnswersAssessmentQuestionId { get; set; }
    }
}