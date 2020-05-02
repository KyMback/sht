using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Questions.WithChoice;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.Questions
{
    [UsedImplicitly]
    internal class ChoiceQuestionTemplateOptionConfig : BaseEntityConfig<ChoiceQuestionTemplateOption>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<ChoiceQuestionTemplateOption> builder)
        {
            builder.Property(e => e.Text).HasLargeMaxLength().IsRequired();
        }
    }
}