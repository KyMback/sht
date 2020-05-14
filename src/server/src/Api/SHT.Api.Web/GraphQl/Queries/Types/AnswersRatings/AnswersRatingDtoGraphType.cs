using HotChocolate.Types;
using SHT.Application.Tests.AnswersRatings.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types.AnswersRatings
{
    public class AnswersRatingDtoGraphType : ObjectType<AnswersRatingDto>
    {
        protected override void Configure(IObjectTypeDescriptor<AnswersRatingDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.QuestionText).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.RatingItems)
                .Type<NonNullType<ListType<NonNullType<AnswersRatingItemDtoGraphType>>>>();
        }
    }
}