using HotChocolate;
using SHT.Api.Web.GraphQl.GraphTypes;

namespace SHT.Api.Web.GraphQl
{
    public static class CustomSchemaBuilder
    {
        public static ISchemaBuilder Configure()
        {
            return SchemaBuilder.New()
                .AddAuthorizeDirectiveType()
                .AddType<UserContextGraphType>()
                .AddQueryType<QueryType>();
        }
    }
}