using AutoMapper;
using JetBrains.Annotations;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Domain.Services;

namespace SHT.Application.Tests.TestSessions
{
    [UsedImplicitly]
    internal class TestSessionsMappingProfile : Profile
    {
        public TestSessionsMappingProfile()
        {
            CreateMap<TestSessionModificationDataDto, TestSessionModificationData>();
            CreateMap<TestSessionVariantDataDto, TestSessionVariantData>();
        }
    }
}