using HotChocolate.Types;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Api.Web.GraphQl.Queries.Paging
{
    public class SearchResultGraphType<TSchemaType, TType> : ObjectType<SearchResult<TType>>, ISearchResult
        where TSchemaType : class, IOutputType
    {
        protected override void Configure(IObjectTypeDescriptor<SearchResult<TType>> descriptor)
        {
            descriptor
                .Field(e => e.Total)
                .Type<NonNullType<IntType>>();

            descriptor
                .Field(e => e.Items)
                .Type<ListType<TSchemaType>>();
        }
    }
}