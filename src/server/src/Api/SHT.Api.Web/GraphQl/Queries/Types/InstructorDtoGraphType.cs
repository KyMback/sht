using HotChocolate.Types;
using SHT.Application.Users.Instructors.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types
{
    public class InstructorDtoGraphType : ObjectType<InstructorDto>
    {
        protected override void Configure(IObjectTypeDescriptor<InstructorDto> descriptor)
        {
            descriptor.Field(e => e.Email).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Id);
        }
    }
}