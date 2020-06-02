using CsvHelper.Configuration;
using SHT.Domain.Questions.Import.Contracts;

namespace SHT.Domain.Questions.Import.ContractsMaps
{
    internal sealed class ChoiceQuestionTemplateOptionImportDtoMap : ClassMap<ChoiceQuestionTemplateOptionImportDto>
    {
        public ChoiceQuestionTemplateOptionImportDtoMap()
        {
            Map(d => d.Text).Name("Text");
            Map(d => d.IsCorrect).Name("IsCorrect");
            Map(d => d.QuestionTemplateId).Name("QuestionTemplateId");
        }
    }
}