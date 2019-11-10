using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using SHT.Api.Web.Constants;
using SHT.Api.Web.Security.Constants;

namespace SHT.Api.Web.Extensions
{
    internal static class MvcCoreBuilderExtensions
    {
        public static IMvcCoreBuilder AddCustomJsonOptions(this IMvcCoreBuilder builder)
        {
            return builder.AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.AllowTrailingCommas = true;
                options.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            });
        }

        public static IMvcCoreBuilder AddCustomCors(this IMvcCoreBuilder builder)
        {
            return builder.AddCors(
                options =>
                {
                    // Create named CORS policies here which you can consume using application.UseCors("PolicyName")
                    // or a [EnableCors("PolicyName")] attribute on your controller or action.
                    options.AddPolicy(
                        CorsPolicyNames.AllowAny,
                        x => x
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
                });
        }

        public static IMvcCoreBuilder AddCustomMvcOptions(this IMvcCoreBuilder builder)
        {
            return builder.AddMvcOptions(
                options =>
                {
                    // Remove string and stream output formatter. These are not useful for an API serving JSON or XML.
                    options.OutputFormatters.RemoveType<StreamOutputFormatter>();
                    options.OutputFormatters.RemoveType<StringOutputFormatter>();

                    // Returns a 406 Not Acceptable if the MIME type in the Accept HTTP header is not valid.
                    options.ReturnHttpNotAcceptable = true;
                });
        }

        public static IMvcCoreBuilder AddCustomDefaultAuthorizationFilter(this IMvcCoreBuilder builder)
        {
            return builder.AddMvcOptions(options =>
            {
                AuthorizationPolicy policy = new AuthorizationPolicyBuilder(AuthenticationDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();

                options.Filters.Add(new AuthorizeFilter(policy));
            });
        }
    }
}