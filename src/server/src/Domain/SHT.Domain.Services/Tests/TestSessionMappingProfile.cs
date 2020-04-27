using System.Linq;
using AutoMapper;
using JetBrains.Annotations;
using MoreLinq;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.Tests.Students;
using SHT.Infrastructure.Common.Extensions;

namespace SHT.Domain.Services.Tests
{
    [UsedImplicitly]
    internal class TestSessionMappingProfile : Profile
    {
        public TestSessionMappingProfile()
        {
            CreateMap<TestSessionModificationData, TestSession>()
                .Map(d => d.Name, s => s.Name)
                .AfterMap((source, destination, ctx) =>
                {
                    destination.StudentTestSessions = source.StudentsIds.LeftJoin(
                        destination.StudentTestSessions,
                        e => e,
                        e => e.StudentId,
                        e => new StudentTestSession
                        {
                            StudentId = e,
                        }, (guid, studentTestSession) => studentTestSession).ToList();

                    destination.TestSessionTestVariants = source.TestVariants.LeftJoin(
                        destination.TestSessionTestVariants,
                        e => e.Name,
                        e => e.Name,
                        e => new TestSessionTestVariant
                        {
                            Name = e.Name,
                            TestVariantId = e.TestVariantId,
                        }, (guid, testVariant) => testVariant).ToList();
                })
                .IgnoreAllOther();
        }
    }
}