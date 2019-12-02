using System;
using System.ComponentModel.DataAnnotations;
using SHT.Application.Common;

namespace SHT.Application.Tests.TestSessions.Get
{
    [ApiDataContract]
    public class TestSessionDto
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string State { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}