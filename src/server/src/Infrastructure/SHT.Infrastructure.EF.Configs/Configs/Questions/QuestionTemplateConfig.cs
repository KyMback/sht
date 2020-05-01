using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Questions;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.Questions
{
    [UsedImplicitly]
    internal class QuestionTemplateConfig : BaseEntityConfig<QuestionTemplate>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<QuestionTemplate> builder)
        {
            builder.Property(e => e.Name).HasMediumMaxLength().IsRequired();

            builder.OwnsOne(e => e.FreeTextQuestionTemplate, navigationBuilder =>
            {
                navigationBuilder.ToTable("FreeTextQuestionTemplate");
                navigationBuilder.HasKey(e => e.Id);
                navigationBuilder.Property(e => e.Question).HasLargeMaxLength().IsRequired();
            });

            builder
                .HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}