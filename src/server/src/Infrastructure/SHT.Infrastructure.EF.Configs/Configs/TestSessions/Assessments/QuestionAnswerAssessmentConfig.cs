using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.TestSessions.Assessments;
using SHT.Domain.Models.TestSessions.Students.Answers;

namespace SHT.Infrastructure.EF.Configs.Configs.TestSessions.Assessments
{
    [UsedImplicitly]
    internal class QuestionAnswerAssessmentConfig : BaseEntityConfig<QuestionAnswerAssessment>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<QuestionAnswerAssessment> builder)
        {
            builder
                .HasOne<StudentQuestionAnswer>()
                .WithOne(e => e.AnswerAssessment)
                .HasForeignKey<QuestionAnswerAssessment>(e => e.StudentQuestionAnswerId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}