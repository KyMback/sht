using HotChocolate.Types;
using SHT.Application.Tests.TestSessions.Contracts.Edit;

namespace SHT.Api.Web.GraphQl.Mutations.Types.TestSession
{
    public class TestSessionVariantInputGraphType : InputObjectType<TestSessionVariantModificationData>
    {
        protected override void Configure(IInputObjectTypeDescriptor<TestSessionVariantModificationData> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.Name).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.IsRandomOrder);
            descriptor.Field(e => e.Questions)
                .Type<NonNullType<ListType<NonNullType<TestSessionVariantQuestionInputGraphType>>>>();
        }
    }
}