using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHT.Domain.Services.TestSessionAssessments
{
    public interface IQuestionsAnswersRatingService
    {
        Task Rate(Guid answersRatingId, IReadOnlyCollection<QuestionsAnswersRatingItemData> ratingItems);
    }
}