using AutoMapper;
using JetBrains.Annotations;
using SHT.Domain.Models.Users;
using SHT.Domain.Users.Accounts;
using SHT.Infrastructure.Common.Extensions;

namespace SHT.Domain.Users.Instructors
{
    [UsedImplicitly]
    internal class InstructorMappingProfile : Profile
    {
        public InstructorMappingProfile()
        {
            CreateMap<InstructorCreationData, AccountCreationData>()
                .Map(d => d.Email, s => s.Email)
                .Map(d => d.Password, s => s.Password)
                .Map(d => d.UserType, _ => UserType.Instructor)
                .IgnoreAllOther();
        }
    }
}