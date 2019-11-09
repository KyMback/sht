using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using SHT.Api.Web.Constants;

namespace SHT.Api.Web.Extensions
{
    internal static class MvcCoreBuilderExtensions
    {
        public static IMvcCoreBuilder AddCustomJsonOptions(
            this IMvcCoreBuilder builder,
            IWebHostEnvironment hostingEnvironment)
        {
            return builder.AddNewtonsoftJson(
                options =>
                {
                    if (hostingEnvironment.IsDevelopment())
                    {
                        // Pretty print the JSON in development for easier debugging.
                        options.SerializerSettings.Formatting = Formatting.Indented;
                    }

                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                    // Parse dates as DateTimeOffset values by default. You should prefer using DateTimeOffset over
                    // DateTime everywhere. Not doing so can cause problems with time-zones.
                    options.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;

                    // Output enumeration values as strings in JSON.
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());

                    // Output dates in host local timezone.
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
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
    }
}