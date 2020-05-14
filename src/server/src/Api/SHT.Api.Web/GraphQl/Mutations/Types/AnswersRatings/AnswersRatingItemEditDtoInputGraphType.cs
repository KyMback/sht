using HotChocolate.Types;
using SHT.Application.Tests.AnswersRatings.Contracts;
using SHT.Application.Tests.AnswersRatings.GetAll;

namespace SHT.Api.Web.GraphQl.Mutations.Types.AnswersRatings
{
    public class AnswersRatingItemEditDtoInputGraphType : InputObjectType<AnswersRatingItemEditDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AnswersRatingItemEditDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.Rating);
        }
    }
}