using HotChocolate.Types;
using SHT.Application.Users.Accounts.ConfirmEmail;

namespace SHT.Api.Web.GraphQl.Mutations.Types
{
    public class ConfirmEmailDataDtoInputGraphType : InputObjectType<ConfirmEmailDataDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ConfirmEmailDataDto> descriptor)
        {
            descriptor.Field(e => e.Email).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Token).Type<NonNullType<StringType>>();
        }
    }
}