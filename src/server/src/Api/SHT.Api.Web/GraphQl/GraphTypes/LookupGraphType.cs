using HotChocolate.Types;
using SHT.Application.Common;

namespace SHT.Api.Web.GraphQl.GraphTypes
{
    public class LookupGraphType : ObjectType<Lookup>
    {
        protected override void Configure(IObjectTypeDescriptor<Lookup> descriptor)
        {
            descriptor.Field(e => e.Text);
            descriptor.Field(e => e.Value);
        }
    }
}