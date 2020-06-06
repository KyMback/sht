using MediatR;
using SHT.Application.Users.Students.Contracts;

namespace SHT.Application.Users.Students.UpdateProfile
{
    public class UpdateStudentProfileRequest : IRequest
    {
        public UpdateStudentProfileRequest(StudentProfileModificationDto data)
        {
            Data = data;
        }

        public StudentProfileModificationDto Data { get; set; }
    }
}