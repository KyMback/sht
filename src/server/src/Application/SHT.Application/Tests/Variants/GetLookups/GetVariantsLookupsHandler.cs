using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Common;
using SHT.Domain.Services.Tests.Variants;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.Variants.GetLookups
{
    [UsedImplicitly]
    internal class GetVariantsLookupsHandler : IRequestHandler<GetVariantsLookupsRequest, IReadOnlyCollection<Lookup>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetVariantsLookupsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IReadOnlyCollection<Lookup>> Handle(
            GetVariantsLookupsRequest request,
            CancellationToken cancellationToken)
        {
            var queryParameters = new TestVariantQueryParameters();

            return _unitOfWork.GetAll(queryParameters, variant => new Lookup(variant.Name, variant.Id.ToString()));
        }
    }
}