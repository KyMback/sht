using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Questions.Contracts;
using SHT.Domain.Questions.Templates;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.QueryParameters.IQueryProvider;

namespace SHT.Application.Questions.GetAll
{
    [UsedImplicitly]
    internal class GetAllQuestionsHandler : IRequestHandler<GetAllQuestionsRequest, IQueryable<QuestionDto>>
    {
        private readonly IQueryProvider _queryProvider;

        public GetAllQuestionsHandler(IQueryProvider queryProvider)
        {
            _queryProvider = queryProvider;
        }

        public Task<IQueryable<QuestionDto>> Handle(GetAllQuestionsRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new QuestionTemplateQueryParameters();
            return Task.FromResult(_queryProvider.Queryable(queryParameters).Select(QuestionDto.Selector));
        }
    }
}