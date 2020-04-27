using HotChocolate;
using HotChocolate.Types;
using MediatR;
using SHT.Api.Web.GraphQl.Common;
using SHT.Api.Web.GraphQl.Mutations;
using SHT.Api.Web.GraphQl.Queries;

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
                .BindClrType<Unit, VoidType>()
                .AddMutationType<GraphQlMutations>()
                .AddQueryType<GraphQlQueries>();
        }
    }

    #pragma warning disable
}