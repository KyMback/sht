using HotChocolate.Types;
using SHT.Application.Users.Accounts.SignIn;

namespace SHT.Api.Web.GraphQl.Mutations.Types
{
    public class SignInResponseGraphType : ObjectType<SignInResponse>
    {
        protected override void Configure(IObjectTypeDescriptor<SignInResponse> descriptor)
        {
            descriptor.Field(e => e.Succeeded);
        }
    }
}