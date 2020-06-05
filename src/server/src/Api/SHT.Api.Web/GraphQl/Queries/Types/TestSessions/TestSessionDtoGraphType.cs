using HotChocolate.Types;
using SHT.Api.Web.GraphQl.Common;
using SHT.Api.Web.GraphQl.Queries.Types.TestSessions.Assessments;
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
            descriptor.Field(e => e.Assessment).Type<NonNullType<AssessmentDtoGraphType>>();
            descriptor.Field(e => e.StudentTestDuration).Type<TimeSpanType>();
        }
    }
}