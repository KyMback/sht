using HotChocolate.Types;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Api.Web.GraphQl.GraphTypes
{
    public class TestSessionVariantDataDtoGraphType : ObjectType<TestSessionVariantDataDto>
    {
        protected override void Configure(IObjectTypeDescriptor<TestSessionVariantDataDto> descriptor)
        {
            descriptor.Field(e => e.Name).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.TestVariantId);
        }
    }
}