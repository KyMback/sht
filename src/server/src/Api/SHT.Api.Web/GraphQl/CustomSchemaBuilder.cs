using HotChocolate;
using HotChocolate.Types;
using SHT.Api.Web.GraphQl.GraphTypes;

namespace SHT.Api.Web.GraphQl
{
    public static class CustomSchemaBuilder
    {
        public static ISchemaBuilder Configure()
        {
            return SchemaBuilder.New()
                .AddAuthorizeDirectiveType()
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