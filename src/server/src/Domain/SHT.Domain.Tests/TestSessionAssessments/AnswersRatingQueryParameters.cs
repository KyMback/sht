using System;
using SHT.Domain.Common.Core;
using SHT.Domain.Models.TestSessions.Assessments;

namespace SHT.Domain.Services.TestSessionAssessments
{
    public class AnswersRatingQueryParameters : BaseQueryParameters<AnswersRating>
    {
        public Guid? Id { get; set; }

        public Guid? StudentId { get; set; }

        public string TestSessionState { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(Id, rating => rating.Id == Id.Value);
            FilterIfHasValue(
                TestSessionState,
                rating => rating.AnswersAssessmentQuestion.Assessment.TestSession.State == TestSessionState);
            FilterIfHasValue(StudentId, rating => rating.StudentId == StudentId.Value);
        }
    }
}