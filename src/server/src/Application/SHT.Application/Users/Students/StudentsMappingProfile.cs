using AutoMapper;
using JetBrains.Annotations;
using SHT.Application.Users.Students.Contracts;
using SHT.Application.Users.Students.SignUp;
using SHT.Domain.Services.Users.Students;

namespace SHT.Application.Users.Students
{
    [UsedImplicitly]
    internal class StudentsMappingProfile : Profile
    {
        public StudentsMappingProfile()
        {
            CreateMap<SignUpStudentDataDto, StudentCreationData>();
        }
    }
}