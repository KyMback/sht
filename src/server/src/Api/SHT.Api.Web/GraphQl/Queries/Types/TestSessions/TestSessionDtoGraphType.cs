using HotChocolate.Types;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types.TestSessions
{
    public class TestSessionDtoGraphType : ObjectType<TestSessionDto>
    {
        protected override void Configure(IObjectTypeDescriptor<TestSessionDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.State).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Name).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.CreatedAt);
            descriptor.Field(e => e.StudentsIds).Type<NonNullType<ListType<NonNullType<UuidType>>>>();
            descriptor.Field(e => e.TestVariants)
                .Type<NonNullType<ListType<NonNullType<TestSessionVariantDtoGraphType>>>>();
        }
    }
}