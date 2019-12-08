using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Tests;

namespace SHT.Infrastructure.EF.Configs.Configs.Tests
{
    [UsedImplicitly]
    internal class QuestionConfig : BaseEntityConfig<Question>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Question> builder)
        {
            builder.Property(e => e.Text).HasMaxLength(LengthConstants.Large).IsRequired();
            builder.Property(e => e.Number).HasMaxLength(LengthConstants.Small).IsRequired();

            builder.HasOne<TestVariant>().WithMany(e => e.Questions).HasForeignKey(e => e.TestVariantId);
        }
    }
}