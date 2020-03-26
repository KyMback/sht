using HotChocolate.Types;
using SHT.Application.Tests.StudentsTestSessions.Contracts;

namespace SHT.Api.Web.GraphQl.GraphTypes
{
    public class StudentTestSessionDtoGraphType : ObjectType<StudentTestSessionDto>
    {
        protected override void Configure(IObjectTypeDescriptor<StudentTestSessionDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.State).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Name).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.TestVariant).Type<StringType>();
            descriptor.Field(e => e.CreatedAt);
        }
    }
}