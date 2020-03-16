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
                // To parse guids with dashes
                .AddType(new UuidType('D'))
                .AddType<UserContextGraphType>()
                .AddType<TestSessionListItemDtoGraphType>()
                .AddQueryType<QueryType>();
        }
    }
}