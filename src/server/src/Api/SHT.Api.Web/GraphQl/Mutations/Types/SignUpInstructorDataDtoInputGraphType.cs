using HotChocolate.Types;
using SHT.Application.Users.Instructors.Contracts;

namespace SHT.Api.Web.GraphQl.Mutations.Types
{
    public class SignUpInstructorDataDtoInputGraphType : InputObjectType<SignUpInstructorDataDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<SignUpInstructorDataDto> descriptor)
        {
            descriptor.Field(e => e.Email).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Password).Type<NonNullType<StringType>>();
        }
    }
}