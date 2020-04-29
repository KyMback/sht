using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.Users;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.Tests
{
    [UsedImplicitly]
    internal class QuestionTemplateConfig : BaseEntityConfig<QuestionTemplate>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<QuestionTemplate> builder)
        {
            builder.Property(e => e.Name).HasMediumMaxLength().IsRequired();
            builder.Property(e => e.Text).HasLargeMaxLength().IsRequired();

            builder
                .HasOne<Instructor>()
                .WithMany()
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}