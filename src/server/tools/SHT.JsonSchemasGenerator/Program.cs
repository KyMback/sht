using System;
using System.Threading.Tasks;
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

            await Generator.Generate(args[0], args[1]);
            ConstantsGenerator.Generate(typeof(TestSessionStates), args[0]);
        }
    }
}