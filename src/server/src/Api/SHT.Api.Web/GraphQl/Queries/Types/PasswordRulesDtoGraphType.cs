using HotChocolate.Types;
using SHT.Application.Users.Accounts.Contracts;
using SHT.Application.Users.Accounts.GetPasswordRules;

namespace SHT.Api.Web.GraphQl.Queries.Types
{
    public class PasswordRulesDtoGraphType : ObjectType<PasswordRulesDto>
    {
        protected override void Configure(IObjectTypeDescriptor<PasswordRulesDto> descriptor)
        {
            descriptor.Field(e => e.RequireDigit);
            descriptor.Field(e => e.RequiredLength);
            descriptor.Field(e => e.RequireLowercase);
            descriptor.Field(e => e.RequireUppercase);
            descriptor.Field(e => e.RequireNonAlphanumeric);
        }
    }
}