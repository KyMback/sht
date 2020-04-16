using HotChocolate.Types;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types
{
    public class TestSessionDetailsDtoGraphType : ObjectType<TestSessionDetailsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<TestSessionDetailsDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.State).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Name).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.StudentsIds).Type<NonNullType<ListType<NonNullType<UuidType>>>>();
            descriptor.Field(e => e.TestVariants)
                .Type<NonNullType<ListType<NonNullType<TestSessionVariantDataDtoGraphType>>>>();
        }
    }
}