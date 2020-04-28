using HotChocolate.Types;
using SHT.Application.Users.Accounts.Contracts;
using SHT.Application.Users.Accounts.SignIn;

namespace SHT.Api.Web.GraphQl.Mutations.Types
{
    public class SignInDataDtoInputGraphType : InputObjectType<SignInDataDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<SignInDataDto> descriptor)
        {
            descriptor.Field(e => e.Login).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Password).Type<NonNullType<StringType>>();
        }
    }
}