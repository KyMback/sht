using HotChocolate.Types;
using SHT.Application.Tests.TestSessions.Contracts.Edit;

namespace SHT.Api.Web.GraphQl.Mutations.Types.TestSession
{
    public class TestSessionVariantChoiceQuestionOptionInputGraphType :
        InputObjectType<TestSessionVariantChoiceQuestionOptionModificationData>
    {
        protected override void Configure(
            IInputObjectTypeDescriptor<TestSessionVariantChoiceQuestionOptionModificationData> descriptor)
        {
            descriptor.Field(e => e.Id).Type<UuidType>();
            descriptor.Field(e => e.Text).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.IsCorrect);
        }
    }
}