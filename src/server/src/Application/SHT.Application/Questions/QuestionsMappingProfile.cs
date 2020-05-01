using AutoMapper;
using JetBrains.Annotations;
using SHT.Application.Questions.Contracts;
using SHT.Domain.Models.Questions;
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
                .ForMember(d => d.FreeTextQuestionTemplate, o =>
                {
                    o.Condition(dto => dto.Type == QuestionType.FreeText);
                    o.MapFrom(s => s.FreeTextQuestionData);
                })
                .IgnoreAllOther();

            CreateMap<FreeTextQuestionDto, FreeTextQuestionTemplate>()
                .Map(d => d.Question, s => s.Question)
                .IgnoreAllOther();
        }
    }
}