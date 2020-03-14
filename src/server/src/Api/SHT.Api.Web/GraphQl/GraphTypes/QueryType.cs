using HotChocolate.Types;

namespace SHT.Api.Web.GraphQl.GraphTypes
{
    public class QueryType : ObjectType<GraphQueries>
    {
        protected override void Configure(IObjectTypeDescriptor<GraphQueries> descriptor)
        {
            descriptor
                .Field(f => f.GetContext(default, default))
                .Name("userContext");
        }
    }
}