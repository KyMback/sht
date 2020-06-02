using CsvHelper.Configuration;
using SHT.Domain.Questions.Import.Contracts;
using SHT.Infrastructure.Services.Csv;

namespace SHT.Domain.Questions.Import.ContractsMaps
{
    internal sealed class QuestionTemplateImportDtoMap : ClassMap<QuestionTemplateImportDto>
    {
        public QuestionTemplateImportDtoMap()
        {
            Map(d => d.Id).Name("Id");
            Map(d => d.Name).Name("Name");
            Map(d => d.QuestionText).Name("QuestionText");
            Map(d => d.Type).Name("Type").Enum();
            Map(d => d.IsShareable).Name("IsShareable");
        }
    }
}