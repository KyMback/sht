using System;
using System.Threading.Tasks;
using CommandLine;
using Microsoft.EntityFrameworkCore;
using SHT.Database.EF.Migrations.CommandLineOptions;
using SHT.Database.EF.Migrations.Seeds;

namespace SHT.Database.EF.Migrations
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<UpdateOptions>(args)
                .WithParsed(opt => Update(opt, args).GetAwaiter().GetResult());
        }

        private static async Task Update(UpdateOptions options, string[] args)
        {
            using MigrationDbContext dbContext = new MigrationDbContextDesignTimeFactory().CreateDbContext(args);
            if (options.Recreate)
            {
                Console.WriteLine("Dropping db...");
                dbContext.Database.EnsureDeleted();
                Console.WriteLine("Db successfully dropped.");
            }

            Console.WriteLine("Apply migrations...");
            await dbContext.Database.MigrateAsync();
            Console.WriteLine("Migrations successfully applied");

            if (options.Recreate && options.WithDevSeeds)
            {
                Console.WriteLine("Apply dev seeds...");
                await SeedsInitializer.InitializeSeeds(dbContext);
                Console.WriteLine("Dev seeds successfully applied");
            }
        }
    }
}