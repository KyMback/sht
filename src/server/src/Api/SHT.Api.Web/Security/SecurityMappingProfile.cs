using AutoMapper;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using SHT.Domain.Users;

namespace SHT.Api.Web.Security
{
    [UsedImplicitly]
    internal class SecurityMappingProfile : Profile
    {
        public SecurityMappingProfile()
        {
            CreateMap<PasswordOptions, PasswordRules>(MemberList.Destination);
        }
    }
}