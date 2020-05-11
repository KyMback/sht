using HotChocolate.Types;
using SHT.Application.Tests.TestSessions.Contracts.Edit;

namespace SHT.Api.Web.GraphQl.Mutations.Types.TestSession
{
    public class TestSessionVariantFreeTextQuestionInputGraphType :
        InputObjectType<TestSessionVariantFreeTextQuestionModificationData>
    {
        protected override void Configure(
            IInputObjectTypeDescriptor<TestSessionVariantFreeTextQuestionModificationData> descriptor)
        {
            descriptor.Field(e => e.QuestionText).Type<NonNullType<StringType>>();
        }
    }
}