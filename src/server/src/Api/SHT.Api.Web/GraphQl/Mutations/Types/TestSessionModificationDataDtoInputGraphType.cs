using HotChocolate.Types;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Api.Web.GraphQl.Mutations.Types
{
    public class TestSessionModificationDataDtoInputGraphType : InputObjectType<TestSessionModificationDataDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<TestSessionModificationDataDto> descriptor)
        {
            // add separate models for update and create
            descriptor.Field(e => e.Name).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.StudentsIds).Type<NonNullType<ListType<NonNullType<UuidType>>>>();
            descriptor.Field(e => e.TestVariants)
                .Type<NonNullType<ListType<NonNullType<TestSessionVariantDataDtoInputGraphType>>>>();
        }
    }
}