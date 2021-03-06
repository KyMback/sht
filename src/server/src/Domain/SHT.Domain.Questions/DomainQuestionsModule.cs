using Autofac;
using SHT.Domain.Questions.Import;
using SHT.Infrastructure.Common.Extensions;

namespace SHT.Domain.Questions
{
    public class DomainQuestionsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterFluentValidators(ThisAssembly)
                .AddAutoMapperTypes(ThisAssembly)
                .AddScopedAsImplementedInterfaces<QuestionTemplateImportService>();
        }
    }
}