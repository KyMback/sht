using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using SHT.Infrastructure.DataAccess.Abstractions;
using SHT.Infrastructure.DataAccess.EF;

namespace SHT.Api.Web.GraphQl.Queries.Paging
{
    public class QueryableOffsetBasedPagingMiddleware<TData>
    {
        private readonly FieldDelegate _next;

        public QueryableOffsetBasedPagingMiddleware(FieldDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(IMiddlewareContext context)
        {
            await _next(context).ConfigureAwait(false);
            IQueryable<TData> source = context.Result switch
            {
                IQueryable<TData> result => result,
                IEnumerable<TData> enumerable => enumerable.AsQueryable(),
                _ => throw new NotSupportedException($"Unsupported result type: {context.Result.GetType()}")
            };

            CancellationToken requestAborted = context.RequestAborted;
            var settings = new PageSettings(context.Argument<int>("pageNumber"), context.Argument<int>("pageSize"));
            context.Result = new SearchResult<TData>(
                await source.WithPaging(settings).ToArrayAsync(requestAborted),
                await source.LongCountAsync(requestAborted));
        }
    }
}