using System;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
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
                if (context.Exception != null)
                {
                    throw new GraphQlException(context.Exception);
                }

                IError error = context.Result.Errors.First();
                if (error.Exception == null)
                {
                    throw new GraphQlException(error.Message);
                }

                throw new GraphQlException(error.Exception);
            }
        }
    }
}