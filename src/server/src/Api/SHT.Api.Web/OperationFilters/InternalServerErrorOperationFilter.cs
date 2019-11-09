using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SHT.Api.Web.OperationFilters
{
    /// <summary>
    ///     Adds a 500 Internal Server Error response to the Swagger response documentation.
    /// </summary>
    /// <seealso cref="IOperationFilter" />
    public class InternalServerErrorOperationFilter : IOperationFilter
    {
        private readonly string _internalServerErrorStatusCode = StatusCodes.Status500InternalServerError.ToString(CultureInfo.InvariantCulture);

        /// <inheritdoc />
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var responses = operation.Responses;
            if (!responses.ContainsKey(_internalServerErrorStatusCode))
            {
                var response = new OpenApiResponse { Description = "Server error." };
                responses.Add(_internalServerErrorStatusCode, response);
            }
        }
    }
}