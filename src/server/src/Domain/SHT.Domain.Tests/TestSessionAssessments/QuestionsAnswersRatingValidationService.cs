using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using SHT.Domain.Models.TestSessions;
using SHT.Domain.Models.TestSessions.Assessments;

namespace SHT.Domain.Services.TestSessionAssessments
{
    [UsedImplicitly]
    internal class QuestionsAnswersRatingValidationService : IQuestionsAnswersRatingValidationService
    {
        public Task ValidateOnRate(AnswersRating rating, IReadOnlyCollection<QuestionsAnswersRatingItemData> ratingItems)
        {
            ThrowIfTestSessionNotInAssessmentPhase(rating);
            // TODO: Validate ratings
            return Task.CompletedTask;
        }

        private void ThrowIfTestSessionNotInAssessmentPhase(AnswersRating rating)
        {
            if (rating.AnswersAssessmentQuestion.Assessment.TestSession.State != TestSessionState.Assessment)
            {
                throw new InvalidOperationException(
                    $"Can't rank answers for test session in not {TestSessionState.Assessment} state");
            }
        }
    }
}