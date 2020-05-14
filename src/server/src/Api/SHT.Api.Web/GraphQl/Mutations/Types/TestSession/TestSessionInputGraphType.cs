using HotChocolate.Types;
using SHT.Api.Web.GraphQl.Mutations.Types.TestSession.Assessments;
using SHT.Application.Tests.TestSessions.Contracts.Edit;

namespace SHT.Api.Web.GraphQl.Mutations.Types.TestSession
{
    public class TestSessionInputGraphType : InputObjectType<TestSessionModificationData>
    {
        protected override void Configure(IInputObjectTypeDescriptor<TestSessionModificationData> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.Name).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.StudentsIds).Type<NonNullType<ListType<NonNullType<UuidType>>>>();
            descriptor.Field(e => e.Variants)
                .Type<NonNullType<ListType<NonNullType<TestSessionVariantInputGraphType>>>>();
            descriptor.Field(e => e.Assessment).Type<NonNullType<AssessmentEditDtoInputGraphType>>();
        }
    }
}