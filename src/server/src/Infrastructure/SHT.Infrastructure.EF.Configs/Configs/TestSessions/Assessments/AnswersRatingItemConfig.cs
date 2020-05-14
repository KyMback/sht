using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.TestSessions.Assessments;

namespace SHT.Infrastructure.EF.Configs.Configs.TestSessions.Assessments
{
    [UsedImplicitly]
    internal class AnswersRatingItemConfig : BaseEntityConfig<AnswersRatingItem>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<AnswersRatingItem> builder)
        {
            builder.HasIndex(e => new
            {
                e.AnswersRatingId,
                e.StudentQuestionAnswerId,
            }).IsUnique();

            builder
                .HasOne(e => e.Answer)
                .WithMany()
                .HasForeignKey(e => e.StudentQuestionAnswerId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}