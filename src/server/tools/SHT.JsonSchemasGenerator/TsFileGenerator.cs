using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NJsonSchema;
using NJsonSchema.CodeGeneration.TypeScript;
using NJsonSchema.Generation;

namespace SHT.JsonSchemasGenerator
{
    public static class TsFileGenerator
    {
        public static void GenerateTsFile(
            string destinationPath,
            IEnumerable<Type> types,
            JsonSchemaGeneratorSettings generatorSettings,
            IEnumerable<string> dataContractTypes)
        {
            var schema = new JsonSchema();
            var resolver = new JsonSchemaResolver(schema, generatorSettings);
            var generator = new JsonSchemaGenerator(generatorSettings);

            Generator.EnsureDestinationDirectoryExists(destinationPath);
            GenerateSchemas(types, resolver, generator, schema);

            GenerateTsFile(destinationPath, schema, dataContractTypes);
        }

        private static void GenerateSchemas(
            IEnumerable<Type> types,
            JsonSchemaResolver resolver,
            JsonSchemaGenerator fileGenerator,
            JsonSchema schema)
        {
            foreach (var t in types)
            {
                if (resolver.Schemas.Any())
                {
                    fileGenerator.Generate(t, resolver);
                }
                else
                {
                    fileGenerator.Generate(schema, t, resolver);
                }
            }
        }

        private static void GenerateTsFile(
            string destinationPath,
            JsonSchema schema,
            IEnumerable<string> dataContractTypes)
        {
            var tsGenerator = new TypeScriptGenerator(schema, CreateTypeScriptGeneratorSettings());
            File.WriteAllText(
                Generator.EnsureFileCreated(destinationPath, "dataContracts.ts"),
                GetTsFileContent(tsGenerator, dataContractTypes));
        }

        private static TypeScriptGeneratorSettings CreateTypeScriptGeneratorSettings()
        {
            return new TypeScriptGeneratorSettings
            {
                ExportTypes = true,
                TypeStyle = TypeScriptTypeStyle.Class,
                PropertyNameGenerator = new TypeScriptPropertyNameGenerator(),
                DateTimeType = TypeScriptDateTimeType.MomentJS,
                HandleReferences = false,
                TypeScriptVersion = 3,
                GenerateConstructorInterface = false,
                GenerateDefaultValues = true,
                NullValue = TypeScriptNullValue.Undefined,
            };
        }

        private static string GetTsFileContent(TypeScriptGenerator tsGenerator, IEnumerable<string> dataContractTypes)
        {
            var ignoreTsLint = "/* eslint-disable */";
            var importMoment = "import moment from \"moment\";";
            var content = $@"{ignoreTsLint}
{importMoment}
{tsGenerator.GenerateFile()}

export type DataContract =
    {string.Join($"{Environment.NewLine}    | ", dataContractTypes.Select(type => $"\"{type}\""))};";

            return content;
        }
    }
}