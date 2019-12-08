using System;
using System.ComponentModel.DataAnnotations;
using SHT.Application.Common;

namespace SHT.Application.Tests.TestSessions.Contracts
{
    [ApiDataContract]
    public class TestSessionVariantDataDto
    {
        public Guid TestVariantId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}