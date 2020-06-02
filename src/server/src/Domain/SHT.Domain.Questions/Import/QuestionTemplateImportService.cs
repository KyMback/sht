using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using SHT.Domain.Models.Questions;
using SHT.Domain.Models.Questions.WithChoice;
using SHT.Domain.Models.Tests;
using SHT.Domain.Questions.Import.Contracts;
using SHT.Domain.Questions.Import.ContractsMaps;
using SHT.Infrastructure.DataAccess.Abstractions;
using SHT.Infrastructure.Services.Csv;

namespace SHT.Domain.Questions.Import
{
    internal class QuestionTemplateImportService : IQuestionTemplateImportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionTemplateImportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ImportCsv(ImportOptions options)
        {
            var templates = await CsvParser.Parse<QuestionTemplateImportDto>(
                options.QuestionTemplatesStreamAccessor,
                typeof(QuestionTemplateImportDtoMap));

            var answerOptions = options.ChoiceQuestionsOptionsStreamAccessor != null
                ? await CsvParser.Parse<ChoiceQuestionTemplateOptionImportDto>(
                    options.ChoiceQuestionsOptionsStreamAccessor,
                    typeof(ChoiceQuestionTemplateOptionImportDtoMap))
                : new List<ChoiceQuestionTemplateOptionImportDto>();

            var data = new QuestionTemplateImportData(
                templates,
                answerOptions
                    .GroupBy(e => e.QuestionTemplateId)
                    .ToDictionary(e => e.Key, e => e.ToArray().AsEnumerable()));

            await Validate(data);
            await ApplyData(data);
        }

        private Task Validate(QuestionTemplateImportData data)
        {
            // TODO: add validation
            return Task.FromResult(data);
        }

        private async Task ApplyData(QuestionTemplateImportData data)
        {
            var templates = data.TemplateImportDtos.Select(e => Map(e, data)).ToArray();
            await _unitOfWork.AddRange(templates);
        }

        private QuestionTemplate Map(QuestionTemplateImportDto dto, QuestionTemplateImportData data)
        {
            var template = new QuestionTemplate
            {
                Name = dto.Name,
                Type = dto.Type,
                IsShareable = dto.IsShareable,
            };

            switch (dto.Type)
            {
                case QuestionType.FreeText:
                    template.FreeTextQuestionTemplate = new FreeTextQuestionTemplate
                    {
                        Question = dto.QuestionText,
                    };
                    break;
                case QuestionType.QuestionWithChoice:
                    template.ChoiceQuestionTemplate = new ChoiceQuestionTemplate
                    {
                        QuestionText = dto.QuestionText,
                        Options = data.TemplateAnswerOptionsImportDtos[dto.Id]
                            .Select(e => new ChoiceQuestionTemplateOption
                            {
                                Text = e.Text,
                                IsCorrect = e.IsCorrect,
                            }).ToList(),
                    };
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(dto.Type), (int)dto.Type, typeof(QuestionType));
            }

            return template;
        }
    }
}