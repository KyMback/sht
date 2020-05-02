using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Questions.WithChoice;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.Questions
{
    [UsedImplicitly]
    internal class ChoiceQuestionTemplateConfig : BaseEntityConfig<ChoiceQuestionTemplate>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<ChoiceQuestionTemplate> builder)
        {
            builder.Property(e => e.QuestionText).HasLargeMaxLength().IsRequired();
            builder.HasMany(e => e.Options)
                .WithOne()
                .HasForeignKey(e => e.ChoiceQuestionTemplateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}