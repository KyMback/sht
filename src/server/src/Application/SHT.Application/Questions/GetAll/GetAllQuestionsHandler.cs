using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Questions.Contracts;
using SHT.Domain.Questions.Templates;
using SHT.Infrastructure.Common;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.QueryParameters.IQueryProvider;

namespace SHT.Application.Questions.GetAll
{
    [UsedImplicitly]
    internal class GetAllQuestionsHandler : IRequestHandler<GetAllQuestionsRequest, IQueryable<QuestionDto>>
    {
        private readonly IQueryProvider _queryProvider;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public GetAllQuestionsHandler(IQueryProvider queryProvider, IExecutionContextAccessor executionContextAccessor)
        {
            _queryProvider = queryProvider;
            _executionContextAccessor = executionContextAccessor;
        }

        public Task<IQueryable<QuestionDto>> Handle(GetAllQuestionsRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new QuestionTemplateQueryParameters
            {
                // TODO: currently user can see only his questions
                CreatedById = _executionContextAccessor.GetCurrentUserId(),
            };
            return Task.FromResult(_queryProvider.Queryable(queryParameters).Select(QuestionDto.Selector));
        }
    }
}