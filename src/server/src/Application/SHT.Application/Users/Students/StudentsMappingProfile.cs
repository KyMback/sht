using AutoMapper;
using JetBrains.Annotations;
using SHT.Application.Users.Students.Contracts;
using SHT.Domain.Models.Users;
using SHT.Domain.Users.Students;

namespace SHT.Application.Users.Students
{
    [UsedImplicitly]
    internal class StudentsMappingProfile : Profile
    {
        public StudentsMappingProfile()
        {
            CreateMap<SignUpStudentDataDto, StudentCreationData>();

            CreateMap<StudentProfileModificationDto, Student>(MemberList.Source);
        }
    }
}