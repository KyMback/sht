using AutoMapper;
using JetBrains.Annotations;
using SHT.Domain.Models.Users;
using SHT.Domain.Services.Users.Accounts;
using SHT.Infrastructure.Common.Extensions;

namespace SHT.Domain.Services.Users.Students
{
    [UsedImplicitly]
    internal class StudentsMappingProfile : Profile
    {
        public StudentsMappingProfile()
        {
            CreateMap<StudentCreationData, AccountCreationData>()
                .Map(d => d.Email, s => s.Email)
                .Map(d => d.Password, s => s.Password)
                .Map(d => d.UserType, s => UserType.Student);
        }
    }
}