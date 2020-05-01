using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Questions.Contracts;
using SHT.Domain.Questions.Templates;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.IQueryProvider;

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
            var s = QuestionDto.Selector;

            return Task.FromResult(queryParameters.ToQuery(_queryProvider).Select(QuestionDto.Selector));
        }
    }
}