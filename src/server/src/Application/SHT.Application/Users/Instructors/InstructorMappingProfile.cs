using AutoMapper;
using JetBrains.Annotations;
using SHT.Application.Users.Instructors.Contracts;
using SHT.Domain.Users.Instructors;
using SHT.Infrastructure.Common.Extensions;

namespace SHT.Application.Users.Instructors
{
    [UsedImplicitly]
    internal class InstructorMappingProfile : Profile
    {
        public InstructorMappingProfile()
        {
            CreateMap<SignUpInstructorDataDto, InstructorCreationData>()
                .Map(d => d.Email, s => s.Email)
                .Map(d => d.Password, s => s.Password)
                .IgnoreAllOther();
        }
    }
}