using HotChocolate.Types;
using SHT.Api.Web.GraphQl.Extensions;
using SHT.Api.Web.GraphQl.GraphTypes;
using SHT.Api.Web.Security.Constants;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Api.Web.GraphQl
{
    public class QueryType : ObjectType<GraphQueries>
    {
        protected override void Configure(IObjectTypeDescriptor<GraphQueries> descriptor)
        {
            descriptor
                .Field(f => f.GetUserContext(default, default))
                .Type<NonNullType<UserContextGraphType>>()
                .Name("userContext");

            descriptor
                .Field(f => f.GetTestSessionListItems(default, default))
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Type<NonNullType<ListType<NonNullType<TestSessionListItemDtoGraphType>>>>()
                .Name("testSessionListItems")
                .UseOffsetBasedPaging<TestSessionListItemDtoGraphType, TestSessionListItemDto>()
                .UseSorting<TestSessionListItemDto>(typeDescriptor =>
                {
                    typeDescriptor.BindFieldsExplicitly();
                    typeDescriptor.Sortable(e => e.CreatedAt);
                });
        }
    }
}