using System.Collections.Generic;
using MediatR;
using SHT.Application.Users.Students.Contracts;

namespace SHT.Application.Users.Students.GetGroups
{
    public class GetStudentsGroupsRequest : IRequest<IReadOnlyCollection<StudentGroupedGroupDto>>
    {
    }
}