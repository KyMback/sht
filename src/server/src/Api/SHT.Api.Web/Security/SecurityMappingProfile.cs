using AutoMapper;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using SHT.Domain.Services.Users;

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