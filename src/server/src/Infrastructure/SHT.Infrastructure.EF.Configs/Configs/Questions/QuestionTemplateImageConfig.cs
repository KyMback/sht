using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Files;
using SHT.Domain.Models.Questions;

namespace SHT.Infrastructure.EF.Configs.Configs.Questions
{
    [UsedImplicitly]
    internal class QuestionTemplateImageConfig : BaseModelConfig<QuestionTemplateImage>
    {
        public override void Configure(EntityTypeBuilder<QuestionTemplateImage> builder)
        {
            builder.HasKey(e => new
            {
                e.FileId,
                e.QuestionTemplateId,
            });

            builder.HasOne<File>()
                .WithMany()
                .HasForeignKey(e => e.FileId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}