using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NJsonSchema;
using NJsonSchema.Generation;
using SHT.Application;
using SHT.Application.Common;

namespace SHT.JsonSchemasGenerator
{
    public static class Generator
    {
        public static async Task Generate(string tsDestinationPath, string schemasDestinationPath)
        {
            var types = GetTypesToConvert();
            var generatorSettings = CreateJsonSchemaGeneratorSettings();

            var dataContractTypes = await JsonSchemaFileGenerator.GenerateJsonSchemasFile(schemasDestinationPath, types, generatorSettings);
            TsFileGenerator.GenerateTsFile(tsDestinationPath, types, generatorSettings, dataContractTypes);
        }

        public static void EnsureDestinationDirectoryExists(string destinationPath)
        {
            Directory.CreateDirectory(destinationPath);
        }

        public static string EnsureFileCreated(string destinationPath, string fileName)
        {
            var path = Path.Combine(destinationPath, fileName);
            File.Create(path).Dispose();
            return path;
        }

        private static List<Type> GetTypesToConvert()
        {
            var types = typeof(ApplicationModule).Assembly.GetTypes()
                .Where(t => t.GetCustomAttribute(typeof(ApiDataContractAttribute)) != null)
                .ToList();

            return types;
        }

        private static JsonSchemaGeneratorSettings CreateJsonSchemaGeneratorSettings()
        {
            return new JsonSchemaGeneratorSettings
            {
                SerializerSettings = GetJsonSettings(),
                SchemaType = SchemaType.JsonSchema,
                SchemaNameGenerator = new DefaultSchemaNameGenerator(),
            };
        }

        private static JsonSerializerSettings GetJsonSettings()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };
            settings.Converters.Add(new StringEnumConverter());

            return settings;
        }
    }
}