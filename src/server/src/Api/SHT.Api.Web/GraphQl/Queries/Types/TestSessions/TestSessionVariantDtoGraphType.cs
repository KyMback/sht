using HotChocolate.Types;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types.TestSessions
{
    public class TestSessionVariantDtoGraphType : ObjectType<TestSessionVariantDto>
    {
        protected override void Configure(IObjectTypeDescriptor<TestSessionVariantDto> descriptor)
        {
            descriptor.Field(e => e.Name).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.IsRandomOrder);
            descriptor.Field(e => e.TestSessionId);
            descriptor.Field(e => e.Questions)
                .Type<NonNullType<ListType<NonNullType<TestSessionVariantQuestionDtoGraphType>>>>();
        }
    }
}