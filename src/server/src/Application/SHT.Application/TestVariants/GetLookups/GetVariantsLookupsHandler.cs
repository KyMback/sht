using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Common;
using SHT.Domain.Services.Tests.Variants;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.TestVariants.GetLookups
{
    [UsedImplicitly]
    internal class GetVariantsLookupsHandler : IRequestHandler<GetVariantsLookupsRequest, IReadOnlyCollection<Lookup>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public GetVariantsLookupsHandler(IUnitOfWork unitOfWork, IExecutionContextAccessor executionContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _executionContextAccessor = executionContextAccessor;
        }

        public Task<IReadOnlyCollection<Lookup>> Handle(
            GetVariantsLookupsRequest request,
            CancellationToken cancellationToken)
        {
            var queryParameters = new TestVariantQueryParameters
            {
                CreatedById = _executionContextAccessor.GetCurrentUserId(),
            };

            return _unitOfWork.GetAll(queryParameters, variant => new Lookup(variant.Name, variant.Id.ToString()));
        }
    }
}