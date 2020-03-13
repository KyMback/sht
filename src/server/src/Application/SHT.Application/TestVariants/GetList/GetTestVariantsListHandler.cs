using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Common.Tables;
using SHT.Application.TestVariants.Contracts;
using SHT.Domain.Services.Tests.Variants;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.TestVariants.GetList
{
    [UsedImplicitly]
    internal class GetTestVariantsListHandler :
        IRequestHandler<GetTestVariantsListRequest, TableResult<TestVariantListItemDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public GetTestVariantsListHandler(IUnitOfWork unitOfWork, IExecutionContextAccessor executionContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _executionContextAccessor = executionContextAccessor;
        }

        public async Task<TableResult<TestVariantListItemDto>> Handle(
            GetTestVariantsListRequest request,
            CancellationToken cancellationToken)
        {
            var queryParameters = new TestVariantQueryParameters
            {
                CreatedById = _executionContextAccessor.GetCurrentUserId(),
            };

            var result = await _unitOfWork.GetSearchResult(queryParameters, variant => new TestVariantListItemDto
            {
                Id = variant.Id,
                Name = variant.Name,
                CreatedByName = variant.CreatedBy.Account.Email,
            });

            return new TableResult<TestVariantListItemDto>(result.Items, result.Total);
        }
    }
}