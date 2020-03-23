using HotChocolate.Types;
using SHT.Application.Users.Students.Contracts;

namespace SHT.Api.Web.GraphQl.GraphTypes
{
    public class StudentGroupedGroupDtoGraphType : ObjectType<StudentGroupedGroupDto>
    {
        protected override void Configure(IObjectTypeDescriptor<StudentGroupedGroupDto> descriptor)
        {
            descriptor.Field(e => e.GroupName).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.StudentsIds).Type<NonNullType<ListType<UuidType>>>();
        }
    }
}