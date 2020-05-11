using HotChocolate.Types;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types.TestSessions
{
    public class TestSessionVariantQuestionDtoGraphType : ObjectType<TestSessionVariantQuestionDto>
    {
        protected override void Configure(IObjectTypeDescriptor<TestSessionVariantQuestionDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.Order);
            descriptor.Field(e => e.Name).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Type).Type<QuestionTypeGraphType>();
            descriptor.Field(e => e.TestSessionVariantId);
            descriptor.Field(e => e.SourceQuestionId);
            descriptor.Field(e => e.FreeTextQuestion).Type<TestSessionVariantFreeTextQuestionDtoGraphType>();
            descriptor.Field(e => e.ChoiceQuestion).Type<TestSessionVariantChoiceQuestionDtoGraphType>();
        }
    }
}