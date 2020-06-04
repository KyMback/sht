using System.Linq;
using AutoMapper;
using JetBrains.Annotations;
using MoreLinq;
using SHT.Application.Questions.Contracts;
using SHT.Domain.Models.Questions;
using SHT.Domain.Models.Questions.WithChoice;
using SHT.Domain.Models.Tests;
using SHT.Infrastructure.Common.Extensions;

namespace SHT.Application.Questions
{
    [UsedImplicitly]
    internal class QuestionsMappingProfile : Profile
    {
        public QuestionsMappingProfile()
        {
            CreateMap<QuestionEditDetailsDto, QuestionTemplate>()
                .Map(d => d.Name, s => s.Name)
                .Map(d => d.Type, s => s.Type)
                .Map(d => d.FreeTextQuestionTemplate,  s => s.FreeTextQuestionData)
                .Map(d => d.ChoiceQuestionTemplate, s => s.ChoiceQuestionData)
                .AfterMap((source, destination, ctx) =>
                {
                    destination.Images = source.Images?.LeftJoin(
                        destination.Images,
                        s => s,
                        d => d.FileId,
                        s => new QuestionTemplateImage
                        {
                            FileId = s,
                        },
                        (optionDto, option) => option).ToList();
                })
                .IgnoreAllOther();

            CreateMap<FreeTextQuestionDto, FreeTextQuestionTemplate>()
                .Map(d => d.Question, s => s.Question)
                .IgnoreAllOther();

            CreateMap<ChoiceQuestionDto, ChoiceQuestionTemplate>()
                .Map(d => d.QuestionText, s => s.QuestionText)
                .AfterMap((dto, template, ctx) =>
                {
                    template.Options = dto.Options.LeftJoin(
                        template.Options,
                        optionDto => optionDto.Id,
                        option => option.Id,
                        optionDto => ctx.Mapper.Map<ChoiceQuestionTemplateOption>(optionDto),
                        (optionDto, option) => ctx.Mapper.Map(optionDto, option)).ToList();
                })
                .IgnoreAllOther();

            CreateMap<ChoiceQuestionOptionDto, ChoiceQuestionTemplateOption>()
                .Map(d => d.Text, s => s.Text)
                .Map(d => d.IsCorrect, s => s.IsCorrect)
                .Map(d => d.IsRequired, s => s.IsCorrect)
                .IgnoreAllOther();
        }
    }
}