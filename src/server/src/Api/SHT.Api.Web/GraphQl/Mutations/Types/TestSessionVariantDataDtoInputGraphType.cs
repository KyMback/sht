using HotChocolate.Types;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Api.Web.GraphQl.Mutations.Types
{
    public class TestSessionVariantDataDtoInputGraphType : InputObjectType<TestSessionVariantDataDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<TestSessionVariantDataDto> descriptor)
        {
            descriptor.Field(e => e.Name).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.TestVariantId).Type<UuidType>();
        }
    }
}