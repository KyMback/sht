using System.Collections.Generic;
using MediatR;

namespace SHT.Application.Users.Students.GetGroups
{
    public class GetStudentsGroupedByGroupsRequest : IRequest<IReadOnlyCollection<StudentGroupedGroupDto>>
    {
    }
}