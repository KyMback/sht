using HotChocolate.Types;
using SHT.Application.Users.Students.SignUp;

namespace SHT.Api.Web.GraphQl.Mutations.Types
{
    public class SignUpStudentDataDtoInputGraphType : InputObjectType<SignUpStudentDataDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<SignUpStudentDataDto> descriptor)
        {
            descriptor.Field(e => e.Email).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Password).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.FirstName).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.LastName).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Group).Type<NonNullType<StringType>>();
        }
    }
}