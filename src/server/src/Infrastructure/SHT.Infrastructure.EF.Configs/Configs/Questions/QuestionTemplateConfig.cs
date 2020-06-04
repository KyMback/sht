using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Questions;
using SHT.Domain.Models.Questions.WithChoice;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.Questions
{
    [UsedImplicitly]
    internal class QuestionTemplateConfig : BaseEntityConfig<QuestionTemplate>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<QuestionTemplate> builder)
        {
            builder.Property(e => e.Name).HasMediumMaxLength().IsRequired();

            builder.HasOne(e => e.FreeTextQuestionTemplate)
                .WithOne()
                .HasForeignKey<FreeTextQuestionTemplate>(e => e.QuestionTemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.ChoiceQuestionTemplate)
                .WithOne()
                .HasForeignKey<ChoiceQuestionTemplate>(e => e.QuestionTemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(e => e.Tags)
                .WithOne()
                .HasForeignKey(e => e.QuestionTemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(e => e.Images)
                .WithOne()
                .HasForeignKey(e => e.QuestionTemplateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}