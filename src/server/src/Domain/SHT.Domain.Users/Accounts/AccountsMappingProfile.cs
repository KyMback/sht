using AutoMapper;
using JetBrains.Annotations;
using SHT.Domain.Models.Users;
using SHT.Infrastructure.Common.Extensions;

namespace SHT.Domain.Users.Accounts
{
    [UsedImplicitly]
    internal class AccountsMappingProfile : Profile
    {
        public AccountsMappingProfile()
        {
            CreateMap<AccountCreationData, Account>()
                .Map(d => d.Email, s => s.Email)
                .Map(d => d.UserType, s => s.UserType)
                .IgnoreAllOther();
        }
    }
}