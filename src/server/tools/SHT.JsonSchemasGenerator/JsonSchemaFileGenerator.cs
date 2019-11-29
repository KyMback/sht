using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NJsonSchema;
using NJsonSchema.Generation;

namespace SHT.JsonSchemasGenerator
{
    public static class JsonSchemaFileGenerator
    {
        public static async Task<IEnumerable<string>> GenerateJsonSchemasFile(
            string destinationPath,
            IEnumerable<Type> types,
            JsonSchemaGeneratorSettings generatorSettings)
        {
            Generator.EnsureDestinationDirectoryExists(destinationPath);
            var schemas =
                await Task.WhenAll(types.Select(type => Task.Run(() => GenerateJsonSchema(type, generatorSettings))));

            var path = Generator.EnsureFileCreated(destinationPath, "schemas.json");
            File.WriteAllText(
                path,
                $"{{{string.Join($",{Environment.NewLine}", schemas.Select(s => $"\"{s.Id}\": {s.ToJson()}"))}}}");
            return schemas.Select(s => s.Id);
        }

        private static JsonSchema GenerateJsonSchema(Type type, JsonSchemaGeneratorSettings generatorSettings)
        {
            var jsonSchema4 = JsonSchema.FromType(type, generatorSettings);
            jsonSchema4.Id = type.Name;
            return jsonSchema4;
        }
    }
}