using HotChocolate.Types;
using SHT.Application.Users.Students.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types
{
    public class StudentProfileDtoGraphType : ObjectType<StudentProfileDto>
    {
        protected override void Configure(IObjectTypeDescriptor<StudentProfileDto> descriptor)
        {
            descriptor.Field(e => e.Email).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Group).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.FirstName).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.LastName).Type<NonNullType<StringType>>();
        }
    }
}