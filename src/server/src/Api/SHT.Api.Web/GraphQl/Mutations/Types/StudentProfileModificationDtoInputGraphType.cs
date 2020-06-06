using HotChocolate.Types;
using SHT.Application.Users.Students.Contracts;

namespace SHT.Api.Web.GraphQl.Mutations.Types
{
    public class StudentProfileModificationDtoInputGraphType : InputObjectType<StudentProfileModificationDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<StudentProfileModificationDto> descriptor)
        {
            descriptor.Field(e => e.Group).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.FirstName).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.LastName).Type<NonNullType<StringType>>();
        }
    }
}