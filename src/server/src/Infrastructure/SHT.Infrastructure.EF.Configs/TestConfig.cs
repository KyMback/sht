using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SHT.Infrastructure.EF.Configs
{
    internal class TestConfig : BaseModelConfig<Test>
    {
        public override void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(200);
        }
    }
}