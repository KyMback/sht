using HotChocolate.Types;
using SHT.Api.Web.GraphQl.Queries.Types.StudentTestSessions.Questions;
using SHT.Application.Tests.AnswersRatings.Contracts;
using SHT.Application.Tests.AnswersRatings.GetAll;

namespace SHT.Api.Web.GraphQl.Queries.Types.AnswersRatings
{
    public class AnswersRatingItemDtoGraphType : ObjectType<AnswersRatingItemDto>
    {
        protected override void Configure(IObjectTypeDescriptor<AnswersRatingItemDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.Rating);
            descriptor.Field(e => e.Answer).Type<NonNullType<StudentQuestionAnswerDtoGraphType>>();
        }
    }
}