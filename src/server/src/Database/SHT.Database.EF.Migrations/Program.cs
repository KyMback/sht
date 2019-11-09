using System;
using CommandLine;
using Microsoft.EntityFrameworkCore;
using SHT.Database.EF.Migrations.CommandLineOptions;

namespace SHT.Database.EF.Migrations
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<UpdateOptions>(args).WithParsed(Update);
        }

        private static void Update(UpdateOptions options)
        {
            using MigrationDbContext dbContext =
                new MigrationDbContextDesignTimeFactory().CreateDbContext(Array.Empty<string>());
            if (options.Recreate)
            {
                Console.WriteLine("Dropping db...");
                dbContext.Database.EnsureDeleted();
                Console.WriteLine("Db successfully dropped.");
            }

            Console.WriteLine("Apply migrations...");
            dbContext.Database.Migrate();
            Console.WriteLine("Migrations successfully applied");
        }
    }
}