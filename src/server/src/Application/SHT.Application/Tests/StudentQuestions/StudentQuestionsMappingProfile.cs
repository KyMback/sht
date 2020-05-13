using AutoMapper;
using JetBrains.Annotations;
using SHT.Application.Tests.StudentQuestions.Contracts;
using SHT.Domain.Services.Student.Questions;
using SHT.Infrastructure.Common.Extensions;

namespace SHT.Application.Tests.StudentQuestions
{
    [UsedImplicitly]
    internal class StudentQuestionsMappingProfile : Profile
    {
        public StudentQuestionsMappingProfile()
        {
            CreateMap<AnswerStudentQuestionDto, QuestionGenericAnswer>()
                .Map(d => d.ChoiceQuestionAnswer, s => s.ChoiceQuestionAnswer)
                .Map(d => d.FreeTextAnswer, s => s.FreeTextAnswer)
                .IgnoreAllOther();

            CreateMap<FreeTextQuestionAnswerDto, QuestionFreeTextAnswer>();
            CreateMap<ChoiceQuestionAnswerDto, ChoiceQuestionAnswer>();
        }
    }
}