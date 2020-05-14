using HotChocolate.Types;
using SHT.Application.Tests.AnswersRatings.Contracts;

namespace SHT.Api.Web.GraphQl.Mutations.Types.AnswersRatings
{
    public class AnswersRatingEditDtoInputGraphType : InputObjectType<AnswersRatingEditDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AnswersRatingEditDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.RatingItems)
                .Type<NonNullType<ListType<NonNullType<AnswersRatingItemEditDtoInputGraphType>>>>();
        }
    }
}