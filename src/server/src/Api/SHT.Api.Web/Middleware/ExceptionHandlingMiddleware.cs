using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SHT.Api.Web.Constants;
using SHT.Api.Web.GraphQl;
using SHT.Domain.Common.Exceptions;
using SHT.Infrastructure.Common.Exceptions;

namespace SHT.Api.Web.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private static readonly IReadOnlyDictionary<Type, (ErrorCode errorCode, int statusCode)> ExceptionsDataMap =
            new Dictionary<Type, (ErrorCode errorCode, int statusCode)>
            {
                { typeof(ValidationException), (ErrorCode.DataIsInvalid, StatusCodes.Status400BadRequest) },
                { typeof(GraphQlException), (ErrorCode.DataIsInvalid, StatusCodes.Status400BadRequest) },
                { typeof(UnauthorizedException), (ErrorCode.Unauthorized, StatusCodes.Status401Unauthorized) },
                {
                    typeof(DbUpdateConcurrencyException),
                    (ErrorCode.ConcurrentModification, StatusCodes.Status409Conflict)
                },
            };

        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);

                if (context.Response.StatusCode >= 400)
                {
                    HandleNonSuccessResponse(context);
                }
            }
            catch (Exception exception)
            {
                HandleException(context, exception);
            }
        }

        private void HandleNonSuccessResponse(HttpContext context)
        {
            switch (context.Response.StatusCode)
            {
                case StatusCodes.Status401Unauthorized:
                    SetError(context, StatusCodes.Status401Unauthorized, ErrorCode.Unauthenticated);
                    break;
                case StatusCodes.Status403Forbidden:
                    SetError(context, StatusCodes.Status403Forbidden, ErrorCode.Unauthorized);
                    break;
                case StatusCodes.Status404NotFound:
                    SetError(context, StatusCodes.Status404NotFound, ErrorCode.RouteNotFound);
                    break;
            }
        }

        private void HandleException(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, $"Error ID: {context.TraceIdentifier}");

            switch (exception)
            {
                case GraphQlException graphQlException:
                    ProcessException(context, graphQlException.InnerException ?? graphQlException);
                    break;
                default:
                    ProcessException(context, exception);
                    break;
            }
        }

        private void ProcessException(HttpContext context, Exception exception)
        {
            if (exception is CodedException businessException)
            {
                SetBusinessExceptionError(context, StatusCodes.Status400BadRequest, businessException);
                return;
            }

            if (ExceptionsDataMap.TryGetValue(exception.GetType(), out var codes))
            {
                SetError(context, codes.statusCode, codes.errorCode);
            }
            else
            {
                SetError(context, StatusCodes.Status500InternalServerError, ErrorCode.UnhandledException);
            }
        }

        private void SetBusinessExceptionError(HttpContext context, int statusCode, CodedException exception)
        {
            SetError(context, statusCode, exception.Code);
            context.Response.Headers[HttpHeaders.ErrorPayload] = exception.Payload != null
                ? JsonConvert.SerializeObject(exception.Payload, Formatting.None)
                : string.Empty;
        }

        private void SetError(HttpContext context, int statusCode, ErrorCode code)
        {
            var errorId = context.TraceIdentifier;
            context.Response.Clear();
            context.Response.StatusCode = statusCode;
            context.Response.Headers[HttpHeaders.ErrorCode] = code.ToString("d");
            context.Response.Headers[HttpHeaders.ErrorId] = errorId;
        }
    }
}