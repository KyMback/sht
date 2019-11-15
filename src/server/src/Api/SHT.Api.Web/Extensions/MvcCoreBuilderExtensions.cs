using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using SHT.Api.Web.Constants;

namespace SHT.Api.Web.Extensions
{
    internal static class MvcCoreBuilderExtensions
    {
        public static IMvcCoreBuilder AddCustomJsonOptions(this IMvcCoreBuilder builder)
        {
            return builder
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
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
                });
        }
    }
}