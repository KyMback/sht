using HotChocolate.Types;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types.TestSessions
{
    public class TestSessionVariantChoiceQuestionOptionDtoGraphType :
        ObjectType<TestSessionVariantChoiceQuestionOptionDto>
    {
        protected override void Configure(IObjectTypeDescriptor<TestSessionVariantChoiceQuestionOptionDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.QuestionId);
            descriptor.Field(e => e.Text).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.IsCorrect);
        }
    }
}