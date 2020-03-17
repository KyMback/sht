using HotChocolate.Types;
using SHT.Api.Web.Security.Constants;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Api.Web.GraphQl.GraphTypes
{
    public class TestSessionListItemDtoGraphType : ObjectType<TestSessionListItemDto>
    {
        protected override void Configure(IObjectTypeDescriptor<TestSessionListItemDto> descriptor)
        {
            descriptor.Authorize(AuthorizationPolicyNames.InstructorsOnly);
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.Name).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.State).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.CreatedAt);
        }
    }
}