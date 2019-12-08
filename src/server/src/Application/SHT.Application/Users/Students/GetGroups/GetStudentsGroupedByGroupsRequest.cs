using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace SHT.Application.Users.Students.GetGroups
{
    public class GetStudentsGroupedByGroupsRequest : IRequest<IReadOnlyCollection<StudentGroupedGroupDto>>
    {
    }
}