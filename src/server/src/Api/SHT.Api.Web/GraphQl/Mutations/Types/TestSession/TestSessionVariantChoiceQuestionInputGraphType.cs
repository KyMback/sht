using HotChocolate.Types;
using SHT.Application.Tests.TestSessions.Contracts.Edit;

namespace SHT.Api.Web.GraphQl.Mutations.Types.TestSession
{
    public class TestSessionVariantChoiceQuestionInputGraphType :
        InputObjectType<TestSessionVariantChoiceQuestionModificationData>
    {
        protected override void Configure(
            IInputObjectTypeDescriptor<TestSessionVariantChoiceQuestionModificationData> descriptor)
        {
            descriptor.Field(e => e.QuestionText).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Options)
                .Type<NonNullType<ListType<NonNullType<TestSessionVariantChoiceQuestionOptionInputGraphType>>>>();
        }
    }
}