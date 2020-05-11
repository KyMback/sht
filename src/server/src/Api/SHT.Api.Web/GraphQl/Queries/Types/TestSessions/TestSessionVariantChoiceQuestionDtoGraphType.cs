using HotChocolate.Types;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types.TestSessions
{
    public class TestSessionVariantChoiceQuestionDtoGraphType : ObjectType<TestSessionVariantChoiceQuestionDto>
    {
        protected override void Configure(IObjectTypeDescriptor<TestSessionVariantChoiceQuestionDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.QuestionText).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Options)
                .Type<NonNullType<ListType<NonNullType<TestSessionVariantChoiceQuestionOptionDtoGraphType>>>>();
        }
    }
}