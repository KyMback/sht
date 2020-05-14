using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SHT.Domain.Models.TestSessions.Assessments;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.TestSessionAssessments
{
    internal class QuestionsAnswersRatingService : IQuestionsAnswersRatingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuestionsAnswersRatingValidationService _questionsAnswersRatingValidationService;

        public QuestionsAnswersRatingService(
            IUnitOfWork unitOfWork,
            IQuestionsAnswersRatingValidationService questionsAnswersRatingValidationService)
        {
            _unitOfWork = unitOfWork;
            _questionsAnswersRatingValidationService = questionsAnswersRatingValidationService;
        }

        public async Task Rate(Guid answersRatingId, IReadOnlyCollection<QuestionsAnswersRatingItemData> ratingItems)
        {
            var queryParams = new AnswersRatingQueryParameters
            {
                Id = answersRatingId,
                IsReadOnly = false,
            };
            AnswersRating rating = await _unitOfWork.GetSingle(queryParams);
            await _questionsAnswersRatingValidationService.ValidateOnRate(rating, ratingItems);

            // TODO: Do it more elegant
            var join = rating.AnswersRatingItems.ToArray().Join(
                ratingItems,
                item => item.Id,
                e => e.Id,
                (target, source) => (Source: source, Target: target)).ToArray();

            foreach (var pair in join)
            {
                pair.Target.Rating = pair.Source.Rating;
            }

            await _unitOfWork.Update(rating);
            await _unitOfWork.Commit();
        }
    }
}