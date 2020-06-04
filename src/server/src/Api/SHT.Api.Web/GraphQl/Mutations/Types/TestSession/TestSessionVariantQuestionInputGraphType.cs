using HotChocolate.Types;
using SHT.Api.Web.GraphQl.Queries.Types;
using SHT.Application.Tests.TestSessions.Contracts.Edit;

namespace SHT.Api.Web.GraphQl.Mutations.Types.TestSession
{
    public class TestSessionVariantQuestionInputGraphType : InputObjectType<TestSessionVariantQuestionModificationData>
    {
        protected override void Configure(IInputObjectTypeDescriptor<TestSessionVariantQuestionModificationData> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.Order);
            descriptor.Field(e => e.Name).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Type).Type<QuestionTypeGraphType>();
            descriptor.Field(e => e.SourceQuestionId);
            descriptor.Field(e => e.FreeTextQuestion).Type<TestSessionVariantFreeTextQuestionInputGraphType>();
            descriptor.Field(e => e.ChoiceQuestion).Type<TestSessionVariantChoiceQuestionInputGraphType>();
            descriptor.Field(e => e.Images).Type<ListType<NonNullType<UuidType>>>();
        }
    }
}