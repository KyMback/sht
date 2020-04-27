using System.Linq;
using MediatR;
using SHT.Application.Users.Students.Contracts;

namespace SHT.Application.Users.Students.GetProfile
{
    public class GetStudentProfileRequest : IRequest<IQueryable<StudentProfileDto>>
    {
    }
}