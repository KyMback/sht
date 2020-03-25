using HotChocolate.Types;
using HotChocolate.Types.Relay;
using SHT.Api.Web.GraphQl.Extensions;
using SHT.Api.Web.GraphQl.GraphTypes;
using SHT.Api.Web.Security.Constants;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Infrastructure.DataAccess.Abstractions;

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
                .UseCustomSelection<TestSessionListItemDto>()
                .UseSorting<TestSessionListItemDto>(typeDescriptor =>
                {
                    typeDescriptor.BindFieldsExplicitly();
                    typeDescriptor.Sortable(e => e.CreatedAt);
                });

            descriptor
                .Field(f => f.GetTestSessionDetails(default, default))
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Type<NonNullType<TestSessionDetailsDtoGraphType>>()
                .Name("testSessionDetails")
                .UseSingleOrDefault()
                // .UseSelection()
                .UseFiltering<TestSessionDetailsDto>(filterDescriptor =>
                    filterDescriptor.Filter(p => p.Id).AllowEquals());

            descriptor
                .Field(f => f.GetTestSessionTriggers(default, default, default))
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Type<NonNullType<ListType<NonNullType<StringType>>>>()
                .Name("testSessionTriggers")
                .Argument("testSessionId", argumentDescriptor => argumentDescriptor.Type<NonNullType<UuidType>>());

            descriptor
                .Field(f => f.GetVariantsLookups(default, default))
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Type<NonNullType<ListType<NonNullType<LookupGraphType>>>>()
                .Name("testVariantLookups")
                .UseSelection();

            descriptor
                .Field(f => f.GetStudentsGroups(default))
                .Authorize()
                .Type<NonNullType<ListType<NonNullType<StudentGroupedGroupDtoGraphType>>>>()
                .Name("studentsGroups");
        }
    }
}