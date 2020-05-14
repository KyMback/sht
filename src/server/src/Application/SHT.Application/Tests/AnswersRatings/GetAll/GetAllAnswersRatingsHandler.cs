using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Tests.AnswersRatings.Contracts;
using SHT.Domain.Models.TestSessions;
using SHT.Domain.Services.TestSessionAssessments;
using SHT.Infrastructure.Common.ExecutionContext;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.QueryParameters.IQueryProvider;

namespace SHT.Application.Tests.AnswersRatings.GetAll
{
    [UsedImplicitly]
    internal class GetAllAnswersRatingsHandler :
        IRequestHandler<GetAllAnswersRatingsRequest, IQueryable<AnswersRatingDto>>
    {
        private readonly IExecutionContextService _executionContextService;
        private readonly IQueryProvider _queryProvider;

        public GetAllAnswersRatingsHandler(
            IExecutionContextService executionContextService,
            IQueryProvider queryProvider)
        {
            _executionContextService = executionContextService;
            _queryProvider = queryProvider;
        }

        public Task<IQueryable<AnswersRatingDto>> Handle(
            GetAllAnswersRatingsRequest request,
            CancellationToken cancellationToken)
        {
            var queryParameters = new AnswersRatingQueryParameters
            {
                StudentId = _executionContextService.GetCurrentUserId(),
                TestSessionState = TestSessionState.Assessment,
            };

            return Task.FromResult(_queryProvider.Queryable(queryParameters).Select(AnswersRatingDto.Selector));
        }
    }
}