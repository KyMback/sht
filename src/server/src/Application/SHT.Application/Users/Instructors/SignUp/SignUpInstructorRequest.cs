using SHT.Application.Common;
using SHT.Application.Users.Instructors.Contracts;

namespace SHT.Application.Users.Instructors.SignUp
{
    public class SignUpInstructorRequest : BaseRequest<SignUpInstructorDataDto>
    {
        public SignUpInstructorRequest(SignUpInstructorDataDto data)
            : base(data)
        {
        }
    }
}