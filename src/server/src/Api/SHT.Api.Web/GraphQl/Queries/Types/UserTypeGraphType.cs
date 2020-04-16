using HotChocolate.Types;
using SHT.Api.Web.GraphQl.Extensions;
using SHT.Domain.Models.Users;

namespace SHT.Api.Web.GraphQl.Queries.Types
{
    public class UserTypeGraphType : EnumType<UserType>
    {
        protected override void Configure(IEnumTypeDescriptor<UserType> descriptor)
        {
            descriptor.UseNamesAsValues();
        }
    }
}