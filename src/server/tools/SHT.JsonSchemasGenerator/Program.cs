using System;
using System.Threading.Tasks;
using SHT.Domain.Models;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.TestSessions;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Domain.Services.Student.StateConfigurations;

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
            ConstantsGenerator.Generate(typeof(StudentTestSessionTriggers), destinationPath);
            ConstantsGenerator.Generate(typeof(StudentTestSessionState), destinationPath);
            ConstantsGenerator.Generate(typeof(StudentTestSessionDataKey), destinationPath);
            ConstantsGenerator.Generate(typeof(TestSessionState), destinationPath);
            ConstantsGenerator.Generate(typeof(LengthConstants), destinationPath);
        }
    }
}