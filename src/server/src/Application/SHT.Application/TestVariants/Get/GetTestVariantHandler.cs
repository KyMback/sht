using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.TestVariants.Contracts;
using SHT.Domain.Services.Tests.Variants;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.TestVariants.Get
{
    [UsedImplicitly]
    internal class GetTestVariantHandler : IRequestHandler<GetTestVariantRequest, TestVariantDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public GetTestVariantHandler(IUnitOfWork unitOfWork, IExecutionContextAccessor executionContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _executionContextAccessor = executionContextAccessor;
        }

        public Task<TestVariantDto> Handle(GetTestVariantRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new TestVariantQueryParameters
            {
                Id = request.Data,
                CreatedById = _executionContextAccessor.GetCurrentUserId(),
            };

            return _unitOfWork.GetSingle(queryParameters, variant => new TestVariantDto
            {
                Name = variant.Name,
                Questions = variant.Questions.Select(e => new TestVariantQuestionDto
                {
                    Id = e.Id,
                    Number = e.Number,
                    Type = e.Type,
                    // TODO: change this stub
                    ShortQuestionLabel = e.Text.Substring(0, 50),
                }).ToArray(),
            });
        }
    }
}