using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Common;
using SHT.Domain.Services.Variants;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.Common.ExecutionContext;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.QueryParameters.IQueryProvider;

namespace SHT.Application.TestVariants.GetLookups
{
    [UsedImplicitly]
    internal class GetTestVariantsLookupsHandler : IRequestHandler<GetTestVariantsLookupsRequest, IQueryable<Lookup>>
    {
        private readonly IQueryProvider _queryProvider;
        private readonly IExecutionContextService _executionContextService;

        public GetTestVariantsLookupsHandler(
            IQueryProvider queryProvider,
            IExecutionContextService executionContextService)
        {
            _queryProvider = queryProvider;
            _executionContextService = executionContextService;
        }

        public Task<IQueryable<Lookup>> Handle(GetTestVariantsLookupsRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new TestVariantQueryParameters
            {
                CreatedById = _executionContextService.GetCurrentUserId(),
            };

            return Task.FromResult(_queryProvider.Queryable(queryParameters).Select(LookupSelectors.VariantSelector));
        }
    }
}