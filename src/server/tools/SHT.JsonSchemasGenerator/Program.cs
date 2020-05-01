using System;
using System.Threading.Tasks;
using SHT.Domain.Models;
using SHT.Domain.Models.Tests;

namespace SHT.JsonSchemasGenerator
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentException($"{nameof(args)} is empty.", nameof(args));
            }

            var destinationPath = args[0];
            await Generator.Generate(destinationPath, args[1]);
            ConstantsGenerator.Generate(typeof(TestSessionStates), destinationPath);
            ConstantsGenerator.Generate(typeof(LengthConstants), destinationPath);
        }
    }
}