using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Questions.Contracts;
using SHT.Domain.Questions.Templates;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.Common.ExecutionContext;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.QueryParameters.IQueryProvider;

namespace SHT.Application.Questions.GetAll
{
    [UsedImplicitly]
    internal class GetAllQuestionsHandler : IRequestHandler<GetAllQuestionsRequest, IQueryable<QuestionDto>>
    {
        private readonly IQueryProvider _queryProvider;
        private readonly IExecutionContextService _executionContextService;

        public GetAllQuestionsHandler(IQueryProvider queryProvider, IExecutionContextService executionContextService)
        {
            _queryProvider = queryProvider;
            _executionContextService = executionContextService;
        }

        public Task<IQueryable<QuestionDto>> Handle(GetAllQuestionsRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new QuestionTemplateQueryParameters
            {
                // TODO: currently user can see only his questions
                CreatedById = _executionContextService.GetCurrentUserId(),
            };
            return Task.FromResult(_queryProvider.Queryable(queryParameters).Select(QuestionDto.Selector));
        }
    }
}