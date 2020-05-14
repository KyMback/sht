using AutoMapper;
using JetBrains.Annotations;
using SHT.Application.Tests.AnswersRatings.Contracts;
using SHT.Domain.Services.TestSessionAssessments;
using SHT.Infrastructure.Common.Extensions;

namespace SHT.Application.Tests.AnswersRatings
{
    [UsedImplicitly]
    internal class AnswersRatingsMappingProfile : Profile
    {
        public AnswersRatingsMappingProfile()
        {
            CreateMap<AnswersRatingItemEditDto, QuestionsAnswersRatingItemData>()
                .Map(d => d.Id, s => s.Id)
                .Map(d => d.Rating, s => s.Rating)
                .IgnoreAllOther();
        }
    }
}