using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using SHT.Application.Common;
using SHT.Domain.Models.Tests;

namespace SHT.Application.Tests.TestSessions.Contracts
{
    [ApiDataContract]
    public class TestSessionVariantDataDto
    {
        public static readonly Expression<Func<TestSessionTestVariant, TestSessionVariantDataDto>> Selector = e =>
            new TestSessionVariantDataDto
            {
                Name = e.Name,
                TestVariantId = e.TestVariantId,
            };

        public Guid TestVariantId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}