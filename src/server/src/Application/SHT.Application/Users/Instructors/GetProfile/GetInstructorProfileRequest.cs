using System.Linq;
using MediatR;
using SHT.Application.Users.Instructors.Contracts;

namespace SHT.Application.Users.Instructors.GetProfile
{
    public class GetInstructorProfileRequest : IRequest<IQueryable<InstructorProfileDto>>
    {
    }
}