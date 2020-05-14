using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.TestSessions.Assessments;

namespace SHT.Infrastructure.EF.Configs.Configs.TestSessions.Assessments
{
    [UsedImplicitly]
    internal class AssessmentConfig : BaseEntityConfig<Assessment>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Assessment> builder)
        {
            builder
                .HasMany(e => e.QuestionAnswerAssessments)
                .WithOne()
                .HasForeignKey(e => e.AssessmentId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder
                .HasMany(e => e.AnswersAssessmentQuestions)
                .WithOne(e => e.Assessment)
                .HasForeignKey(e => e.AssessmentId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}