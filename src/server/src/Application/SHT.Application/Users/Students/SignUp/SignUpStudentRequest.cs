using SHT.Application.Common;

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