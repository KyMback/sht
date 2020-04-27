using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.Users;

namespace SHT.Infrastructure.EF.Configs.Configs.Tests
{
    [UsedImplicitly]
    internal class QuestionConfig : BaseEntityConfig<Question>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Question> builder)
        {
            builder.Property(e => e.Text).HasMaxLength(LengthConstants.Large).IsRequired();

            builder
                .HasOne<Instructor>()
                .WithMany()
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}