using AutoMapper;
using JetBrains.Annotations;
using SHT.Application.Users.Accounts.Contracts;
using SHT.Application.Users.Accounts.GetPasswordRules;
using SHT.Domain.Users;

namespace SHT.Application.Users.Accounts
{
    [UsedImplicitly]
    internal class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<PasswordRules, PasswordRulesDto>();
            CreateMap<SignInDataDto, LoginData>();
        }
    }
}