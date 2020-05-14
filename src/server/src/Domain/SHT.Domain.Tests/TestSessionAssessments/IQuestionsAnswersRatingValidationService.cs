using System.Collections.Generic;
using System.Threading.Tasks;
using SHT.Domain.Models.TestSessions.Assessments;

namespace SHT.Domain.Services.TestSessionAssessments
{
    internal interface IQuestionsAnswersRatingValidationService
    {
        Task ValidateOnRate(AnswersRating rating, IReadOnlyCollection<QuestionsAnswersRatingItemData> ratingItems);
    }
}