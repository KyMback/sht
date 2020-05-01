using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models;
using SHT.Domain.Models.Tests.Students;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.Tests.Students
{
    [UsedImplicitly]
    internal class StudentQuestionConfig : BaseEntityConfig<StudentQuestion>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<StudentQuestion> builder)
        {
            builder.Property(e => e.Text).HasLargeMaxLength().IsRequired();
            builder.Property(e => e.Answer).HasLargeMaxLength();
            builder.Property(e => e.Number).HasSmallMaxLength().IsRequired();
        }
    }
}