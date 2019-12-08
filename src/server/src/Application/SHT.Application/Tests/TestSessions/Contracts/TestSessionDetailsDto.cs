using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SHT.Application.Common;

namespace SHT.Application.Tests.TestSessions.Contracts
{
    [ApiDataContract]
    public class TestSessionDetailsDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public IReadOnlyCollection<Guid> StudentsIds { get; set; }

        [Required]
        public IReadOnlyCollection<TestSessionVariantDataDto> TestVariants { get; set; }
    }
}