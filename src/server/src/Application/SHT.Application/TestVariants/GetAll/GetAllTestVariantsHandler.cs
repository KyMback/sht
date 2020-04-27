using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.TestVariants.Contracts;
using SHT.Domain.Services.Tests.Variants;
using SHT.Infrastructure.Common;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.IQueryProvider;

namespace SHT.Application.TestVariants.GetAll
{
    [UsedImplicitly]
    internal class GetAllTestVariantsHandler : IRequestHandler<GetAllTestVariantsRequest, IQueryable<TestVariantDto>>
    {
        private readonly IExecutionContextAccessor _executionContextAccessor;
        private readonly IQueryProvider _queryProvider;

        public GetAllTestVariantsHandler(
            IExecutionContextAccessor executionContextAccessor,
            IQueryProvider queryProvider)
        {
            _executionContextAccessor = executionContextAccessor;
            _queryProvider = queryProvider;
        }

        public Task<IQueryable<TestVariantDto>> Handle(GetAllTestVariantsRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new TestVariantQueryParameters
            {
                CreatedById = _executionContextAccessor.GetCurrentUserId(),
            };

            return Task.FromResult(queryParameters.ToQuery(_queryProvider).Select(TestVariantDto.Selector));
        }
    }
}