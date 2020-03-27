using HotChocolate;
using HotChocolate.Types;
using SHT.Api.Web.GraphQl.GraphTypes;
using SHT.Api.Web.GraphQl.GraphTypes.StudentTestSessions;

namespace SHT.Api.Web.GraphQl
{
    public static class CustomSchemaBuilder
    {
        public static ISchemaBuilder Configure()
        {
            return SchemaBuilder.New()
                .AddAuthorizeDirectiveType()
                // To restrict max number of fields in one page
                .AddType(new PaginationAmountType(100))
                .ModifyOptions(e => e.DefaultBindingBehavior = BindingBehavior.Explicit)
                .AddType<UserContextGraphType>()
                .AddType<TestSessionListItemDtoGraphType>()
                .AddType<TestSessionDetailsDtoGraphType>()
                .AddType<TestSessionVariantDataDtoGraphType>()
                .AddType<LookupGraphType>()
                .AddType<StudentGroupedGroupDtoGraphType>()
                .AddQueryType<QueryType>();
        }
    }
}