using CommandLine;

namespace SHT.Database.EF.Migrations.CommandLineOptions
{
    [Verb("update", HelpText = "Apply migrations")]
    internal class UpdateOptions
    {
        [Option("recreate", Default = false, HelpText = "Recreates db if specified")]
        public bool Recreate { get; set; }

        [Option("dev-seeds", Default = false, HelpText = "Adds dev seeds if specified")]
        public bool WithDevSeeds { get; set; }
    }
}