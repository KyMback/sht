using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SHT.Database.EF.Migrations.Settings;

namespace SHT.Database.EF.Migrations
{
    [UsedImplicitly]
    internal class MigrationDbContextDesignTimeFactory : IDesignTimeDbContextFactory<MigrationDbContext>
    {
        public MigrationDbContext CreateDbContext(string[] args)
        {
            ApplicationSettings cfg = AppConfigurationBuilder.Build();
            var optionsBuilder =
                new DbContextOptionsBuilder<MigrationDbContext>()
                    .UseNpgsql(cfg.ConnectionOptions.ConnectionString);

            return new MigrationDbContext(optionsBuilder.Options);
        }
    }
}