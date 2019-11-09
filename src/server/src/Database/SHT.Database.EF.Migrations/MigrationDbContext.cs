using Microsoft.EntityFrameworkCore;
using SHT.Infrastructure.EF.Configs;

namespace SHT.Database.EF.Migrations
{
    public class MigrationDbContext : DbContext
    {
        public MigrationDbContext(DbContextOptions<MigrationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelsConfigsApplier.Configure(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}