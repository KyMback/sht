using System;
using System.Threading.Tasks;
using SHT.Application.StateMachineConfigs.StudentTestSessions;
using SHT.Domain.Models;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.TestSessions;
using SHT.Domain.Models.TestSessions.Students;

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
            ConstantsGenerator.Generate(typeof(TestSessionStates), destinationPath);
            ConstantsGenerator.Generate(typeof(LengthConstants), destinationPath);
        }
    }
}