using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.TestSessionAssessments;

namespace SHT.Application.Tests.AnswersRatings.Rank
{
    [UsedImplicitly]
    internal class RankQuestionsAnswersHandler : IRequestHandler<RankQuestionsAnswersRequest>
    {
        private readonly IQuestionsAnswersRatingService _questionsAnswersRatingService;
        private readonly IMapper _mapper;

        public RankQuestionsAnswersHandler(
            IQuestionsAnswersRatingService questionsAnswersRatingService,
            IMapper mapper)
        {
            _questionsAnswersRatingService = questionsAnswersRatingService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RankQuestionsAnswersRequest request, CancellationToken cancellationToken)
        {
            var items = _mapper.Map<IReadOnlyCollection<QuestionsAnswersRatingItemData>>(request.Data.RatingItems);
            await _questionsAnswersRatingService.Rate(request.Data.Id, items);
            return default;
        }
    }
}