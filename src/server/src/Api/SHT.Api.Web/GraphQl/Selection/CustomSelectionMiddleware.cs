using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Resolvers;
using HotChocolate.Utilities;

namespace SHT.Api.Web.GraphQl.Selection
{
    public class CustomSelectionMiddleware<T>
    {
        private readonly FieldDelegate _next;
        private readonly ITypeConversion _converter;

        public CustomSelectionMiddleware(
            FieldDelegate next,
            ITypeConversion converter)
        {
            _next = next;
            _converter = converter ?? TypeConversion.Default;
        }

        public async Task InvokeAsync(IMiddlewareContext context)
        {
            await _next(context).ConfigureAwait(false);

            IQueryable<T> source = context.Result switch
            {
                IQueryable<T> queryable => queryable,
                IEnumerable<T> enumerable => enumerable.AsQueryable(),
                _ => throw new NotSupportedException($"Unsupported result type: {context.Result.GetType()}")
            };

            var visitor = new CustomSelectionVisitor(context, _converter);
            visitor.Accept(context.Field);
            context.Result = source.Select(visitor.Project<T>());
        }
    }
}