using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Users.Students.Contracts;
using SHT.Domain.Services.Users;
using SHT.Infrastructure.Common;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.IQueryProvider;

namespace SHT.Application.Users.Students.GetProfile
{
    [UsedImplicitly]
    internal class GetStudentProfileHandler : IRequestHandler<GetStudentProfileRequest, IQueryable<StudentProfileDto>>
    {
        private readonly IQueryProvider _queryProvider;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public GetStudentProfileHandler(
            IQueryProvider queryProvider,
            IExecutionContextAccessor executionContextAccessor)
        {
            _queryProvider = queryProvider;
            _executionContextAccessor = executionContextAccessor;
        }

        public Task<IQueryable<StudentProfileDto>> Handle(GetStudentProfileRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new StudentQueryParameters(_executionContextAccessor.GetCurrentUserId());
            return Task.FromResult(queryParameters.ToQuery(_queryProvider).Select(StudentProfileDto.Selector));
        }
    }
}