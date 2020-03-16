using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Common.Tables;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Domain.Services.Tests;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.TestSessions.GetList
{
    [UsedImplicitly]
    internal class GetAllTestSessionsHandler :
        IRequestHandler<GetAllTestSessionsRequest, TableResult<TestSessionListItemDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public GetAllTestSessionsHandler(IUnitOfWork unitOfWork, IExecutionContextAccessor executionContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _executionContextAccessor = executionContextAccessor;
        }

        public async Task<TableResult<TestSessionListItemDto>> Handle(
            GetAllTestSessionsRequest request,
            CancellationToken cancellationToken)
        {
            var filter = request.Data;
            var queryParameters = new TestSessionQueryParameters
            {
                PagingSettings = new PageSettings(filter.PageNumber, filter.PageSize),
                DescByCreatedAt = true,
                InstructorId = _executionContextAccessor.GetCurrentUserId(),
            };
            var result = await _unitOfWork.GetSearchResult(queryParameters, session => new TestSessionListItemDto
            {
                Id = session.Id,
                Name = session.Name,
                State = session.State,
                CreatedAt = session.CreatedAt,
            });

            return new TableResult<TestSessionListItemDto>(result.Items, result.Total);
        }
    }
}