using System.Collections.Generic;
using SHT.Domain.Questions.Import.Contracts;

namespace SHT.Domain.Questions.Import
{
    internal class QuestionTemplateImportData
    {
        public QuestionTemplateImportData(
            IEnumerable<QuestionTemplateImportDto> templateImportDtos,
            IDictionary<string, IEnumerable<ChoiceQuestionTemplateOptionImportDto>> templateAnswerOptionsImportDtos)
        {
            TemplateImportDtos = templateImportDtos;
            TemplateAnswerOptionsImportDtos = templateAnswerOptionsImportDtos;
        }

        public IEnumerable<QuestionTemplateImportDto> TemplateImportDtos { get; set; }

        public IDictionary<string, IEnumerable<ChoiceQuestionTemplateOptionImportDto>> TemplateAnswerOptionsImportDtos { get; set; }
    }
}