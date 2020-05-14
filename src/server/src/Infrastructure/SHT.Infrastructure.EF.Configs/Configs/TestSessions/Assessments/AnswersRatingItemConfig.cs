using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.TestSessions.Assessments;
using SHT.Domain.Models.TestSessions.Students.Answers;

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
                .HasOne<StudentQuestionAnswer>()
                .WithMany()
                .HasForeignKey(e => e.StudentQuestionAnswerId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}