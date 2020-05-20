using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Questions;

namespace SHT.Infrastructure.EF.Configs.Configs.Questions
{
    [UsedImplicitly]
    internal class QuestionTemplateTagConfig : BaseModelConfig<QuestionTemplateTag>
    {
        public override void Configure(EntityTypeBuilder<QuestionTemplateTag> builder)
        {
            builder.ToTable("QuestionTemplate_Tag");
            builder.HasKey(e => new
            {
                e.TagId,
                e.QuestionTemplateId,
            });

            builder
                .HasOne(e => e.Tag)
                .WithMany()
                .HasForeignKey(e => e.TagId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}