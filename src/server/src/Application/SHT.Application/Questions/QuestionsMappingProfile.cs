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
                .ForMember(d => d.FreeTextQuestionTemplate,  o => o.MapFrom(s => s.FreeTextQuestionData))
                .ForMember(d => d.ChoiceQuestionTemplate, o => o.MapFrom(s => s.ChoiceQuestionData))
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
                .IgnoreAllOther();
        }
    }
}