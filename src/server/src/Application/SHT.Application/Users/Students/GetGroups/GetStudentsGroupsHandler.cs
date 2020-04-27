using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Users.Students.Contracts;
using SHT.Domain.Services.Users;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Users.Students.GetGroups
{
    [UsedImplicitly]
    internal class GetStudentsGroupsHandler : IRequestHandler<GetStudentsGroupsRequest, IReadOnlyCollection<StudentGroupedGroupDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStudentsGroupsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<StudentGroupedGroupDto>> Handle(GetStudentsGroupsRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new StudentQueryParameters
            {
                IsUniq = true,
            };

            var result = await _unitOfWork.GetAll(queryParameters, student => new
            {
                student.Id,
                student.Group,
            });

            return result
                .GroupBy(e => e.Group, arg => arg.Id)
                .Select(group =>
                    new StudentGroupedGroupDto
                    {
                        GroupName = group.Key,
                        StudentsIds = group.ToArray(),
                    }).ToArray();
        }
    }
}