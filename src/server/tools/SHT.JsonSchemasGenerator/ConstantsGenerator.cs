using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SHT.Common.Utils;
using SHT.Domain.Models.Tests;

namespace SHT.JsonSchemasGenerator
{
    public static class ConstantsGenerator
    {
        public static void Generate(Type type, string destinationPath)
        {
            IReadOnlyDictionary<string, object> fields = TypeUtils.GetAllConstFields(typeof(TestSessionStates));
            var content = GetContent(type, JsonConvert.SerializeObject(fields, Formatting.Indented));

            string path = GetPath(destinationPath, type);

            File.Create(path).Dispose();
            File.WriteAllText(path, content);
        }

        private static string GetPath(string destinationPath, Type type)
        {
            return Path.Combine(destinationPath, $"{char.ToLowerInvariant(type.Name[0]) + type.Name.Substring(1)}.ts");
        }

        private static string GetContent(Type type, string content)
        {
            return $"/* eslint-disable */{Environment.NewLine}" +
                   $"export const {type.Name} = {content} as const;{Environment.NewLine}";
        }
    }
}