using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Common;
using SHT.Domain.Services.Variants;
using SHT.Infrastructure.Common;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.IQueryProvider;

namespace SHT.Application.TestVariants.GetLookups
{
    [UsedImplicitly]
    internal class GetTestVariantsLookupsHandler : IRequestHandler<GetTestVariantsLookupsRequest, IQueryable<Lookup>>
    {
        private readonly IQueryProvider _queryProvider;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public GetTestVariantsLookupsHandler(
            IQueryProvider queryProvider,
            IExecutionContextAccessor executionContextAccessor)
        {
            _queryProvider = queryProvider;
            _executionContextAccessor = executionContextAccessor;
        }

        public Task<IQueryable<Lookup>> Handle(GetTestVariantsLookupsRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new TestVariantQueryParameters
            {
                CreatedById = _executionContextAccessor.GetCurrentUserId(),
            };

            return Task.FromResult(queryParameters.ToQuery(_queryProvider).Select(LookupSelectors.VariantSelector));
        }
    }
}