using System.Threading.Tasks;
using HotChocolate.Execution;
using SHT.Common.Extensions;

namespace SHT.Api.Web.GraphQl
{
    public class CustomGraphQlExceptionHandlingMiddleware
    {
        private readonly QueryDelegate _next;

        public CustomGraphQlExceptionHandlingMiddleware(QueryDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(IQueryContext context)
        {
            await _next(context).ConfigureAwait(false);
            if (context.Exception != null || !context.Result.Errors.IsNullOrEmpty())
            {
                throw context.Exception ?? new GraphQlException(context.Result.Errors);
            }
        }
    }
}