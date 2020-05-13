using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.TestVariants.Contracts;
using SHT.Domain.Services.Variants;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.Common.ExecutionContext;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.QueryParameters.IQueryProvider;

namespace SHT.Application.TestVariants.GetAll
{
    [UsedImplicitly]
    internal class GetAllTestVariantsHandler : IRequestHandler<GetAllTestVariantsRequest, IQueryable<TestVariantDto>>
    {
        private readonly IExecutionContextService _executionContextService;
        private readonly IQueryProvider _queryProvider;

        public GetAllTestVariantsHandler(
            IExecutionContextService executionContextService,
            IQueryProvider queryProvider)
        {
            _executionContextService = executionContextService;
            _queryProvider = queryProvider;
        }

        public Task<IQueryable<TestVariantDto>> Handle(GetAllTestVariantsRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new TestVariantQueryParameters
            {
                CreatedById = _executionContextService.GetCurrentUserId(),
            };

            return Task.FromResult(_queryProvider.Queryable(queryParameters).Select(TestVariantDto.Selector));
        }
    }
}