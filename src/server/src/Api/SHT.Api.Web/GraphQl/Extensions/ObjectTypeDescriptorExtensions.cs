using HotChocolate.Types;
using SHT.Api.Web.GraphQl.Paging;

namespace SHT.Api.Web.GraphQl.Extensions
{
    public static class ObjectTypeDescriptorExtensions
    {
        public static IObjectFieldDescriptor UseOffsetBasedPaging<TSchemaType, TType>(this IObjectFieldDescriptor descriptor)
            where TSchemaType : class, IOutputType
        {
            descriptor
                .AddOffsetBasedPagingArguments()
                .Type<SearchResultGraphType<TSchemaType, TType>>()
                .Use<QueryableOffsetBasedPagingMiddleware<TType>>();

            return descriptor;
        }

        private static IObjectFieldDescriptor AddOffsetBasedPagingArguments(
            this IObjectFieldDescriptor descriptor)
        {
            return descriptor
                .Argument("pageNumber", a => a.Type<NonNullType<IntType>>())
                .Argument("pageSize", a => a.Type<NonNullType<IntType>>());
        }
    }
}