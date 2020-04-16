using System;
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
            try
            {
                await _next(context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (context.Exception != null || !context.Result.Errors.IsNullOrEmpty())
            {
                throw context.Exception ?? new GraphQlException(context.Result.Errors);
            }
        }
    }
}