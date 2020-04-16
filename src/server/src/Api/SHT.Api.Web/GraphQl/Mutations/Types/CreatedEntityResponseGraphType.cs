using HotChocolate.Types;
using SHT.Application.Common;

namespace SHT.Api.Web.GraphQl.Mutations.Types
{
    public class CreatedEntityResponseGraphType : ObjectType<CreatedEntityResponse>
    {
        protected override void Configure(IObjectTypeDescriptor<CreatedEntityResponse> descriptor)
        {
            descriptor.Field(e => e.Id);
        }
    }
}