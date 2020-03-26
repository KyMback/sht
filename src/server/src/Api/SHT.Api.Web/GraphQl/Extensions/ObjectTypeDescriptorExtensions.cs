using HotChocolate.Types;
using SHT.Api.Web.GraphQl.Paging;
using SHT.Api.Web.GraphQl.Selection;

namespace SHT.Api.Web.GraphQl.Extensions
{
    public static class ObjectTypeDescriptorExtensions
    {
        public static IObjectFieldDescriptor UseCustomSelection<TType>(this IObjectFieldDescriptor descriptor)
        {
            descriptor
                .Use<CustomSelectionMiddleware<TType>>();

            return descriptor;
        }

        /// <summary>
        /// https://github.com/ChilliCream/hotchocolate/issues/1509
        /// </summary>
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