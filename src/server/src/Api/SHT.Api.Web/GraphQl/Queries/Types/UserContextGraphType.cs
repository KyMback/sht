using HotChocolate.Types;
using SHT.Application.Users.Accounts.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types
{
    public class UserContextGraphType : ObjectType<UserContextDto>
    {
        protected override void Configure(IObjectTypeDescriptor<UserContextDto> descriptor)
        {
            descriptor.Field(e => e.Id).Type<UuidType>();
            descriptor.Field(e => e.UserType).Type<UserTypeGraphType>();
            descriptor.Field(e => e.Culture).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.IsAuthenticated).Type<NonNullType<BooleanType>>();
        }
    }
}