using HotChocolate.Types;
using SHT.Application.Users.Instructors.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types
{
    public class InstructorProfileDtoGraphType : ObjectType<InstructorProfileDto>
    {
        protected override void Configure(IObjectTypeDescriptor<InstructorProfileDto> descriptor)
        {
            descriptor.Field(e => e.Email).Type<NonNullType<StringType>>();
        }
    }
}