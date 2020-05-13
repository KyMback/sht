using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Domain.Models.TestSessions.Students.Answers;

namespace SHT.Infrastructure.EF.Configs.Configs.TestSessions.Students
{
    [UsedImplicitly]
    internal class StudentQuestionAnswerConfig : BaseEntityConfig<StudentQuestionAnswer>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<StudentQuestionAnswer> builder)
        {
            builder
                .HasOne<StudentTestSessionQuestion>()
                .WithMany()
                .HasForeignKey(e => e.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.FreeTextAnswer)
                .WithOne()
                .HasForeignKey<StudentFreeTextQuestionAnswer>(e => e.Id)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder
                .HasMany(e => e.ChoiceQuestionAnswers)
                .WithOne()
                .HasForeignKey(e => e.StudentQuestionAnswerId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}