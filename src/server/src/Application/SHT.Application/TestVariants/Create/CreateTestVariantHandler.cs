using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Common;
using SHT.Application.TestVariants.Contracts;
using SHT.Domain.Services.Tests.Variants;
using SHT.Infrastructure.Common.Transactions;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.TestVariants.Create
{
    [UsedImplicitly]
    internal class CreateTestVariantHandler : IRequestHandler<CreateTestVariantRequest, CreatedEntityResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITestVariantService _testVariantService;

        public CreateTestVariantHandler(IUnitOfWork unitOfWork, ITestVariantService testVariantService)
        {
            _unitOfWork = unitOfWork;
            _testVariantService = testVariantService;
        }

        public Task<CreatedEntityResponse> Handle(CreateTestVariantRequest request, CancellationToken cancellationToken)
        {
            TestVariantSaveDataDto data = request.Data;
            using var scope = TransactionsFactory.Create();
            return Task.FromResult(new CreatedEntityResponse());
        }
    }
}