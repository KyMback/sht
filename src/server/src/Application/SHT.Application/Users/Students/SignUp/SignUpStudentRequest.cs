using SHT.Application.Common;
using SHT.Application.Users.Students.Contracts;

namespace SHT.Application.Users.Students.SignUp
{
    public class SignUpStudentRequest : BaseRequest<SignUpStudentDataDto>
    {
        public SignUpStudentRequest(SignUpStudentDataDto data)
            : base(data)
        {
        }
    }
}