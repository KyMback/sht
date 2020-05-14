using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.TestSessions.Assessments;
using SHT.Domain.Models.Users;

namespace SHT.Infrastructure.EF.Configs.Configs.TestSessions.Assessments
{
    [UsedImplicitly]
    internal class AnswersRatingConfig : BaseEntityConfig<AnswersRating>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<AnswersRating> builder)
        {
            builder
                .HasOne<Student>()
                .WithMany()
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(e => e.AnswersRatingItems)
                .WithOne()
                .HasForeignKey(e => e.AnswersRatingId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}