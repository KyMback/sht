using HotChocolate.Types;
using SHT.Application.Files.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types
{
    public class FileInfoDtoGraphType : ObjectType<FileInfoDto>
    {
        protected override void Configure(IObjectTypeDescriptor<FileInfoDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.Name).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.ContentType).Type<NonNullType<StringType>>();
        }
    }
}