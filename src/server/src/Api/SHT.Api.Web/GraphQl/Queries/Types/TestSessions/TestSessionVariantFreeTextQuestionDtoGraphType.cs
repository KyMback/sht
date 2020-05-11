using HotChocolate.Types;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types.TestSessions
{
    public class TestSessionVariantFreeTextQuestionDtoGraphType : ObjectType<TestSessionVariantFreeTextQuestionDto>
    {
        protected override void Configure(IObjectTypeDescriptor<TestSessionVariantFreeTextQuestionDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.QuestionText).Type<NonNullType<StringType>>();
        }
    }
}