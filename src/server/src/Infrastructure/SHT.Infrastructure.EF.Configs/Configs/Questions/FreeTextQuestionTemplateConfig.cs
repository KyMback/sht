using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Questions;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.Questions
{
    [UsedImplicitly]
    internal class FreeTextQuestionTemplateConfig : BaseEntityConfig<FreeTextQuestionTemplate>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<FreeTextQuestionTemplate> builder)
        {
            builder.Property(e => e.Question).HasLargeMaxLength().IsRequired();
        }
    }
}