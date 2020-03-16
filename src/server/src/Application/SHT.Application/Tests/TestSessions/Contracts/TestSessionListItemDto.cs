using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using SHT.Application.Common;
using SHT.Domain.Models.Tests;

namespace SHT.Application.Tests.TestSessions.Contracts
{
    [ApiDataContract]
    public class TestSessionListItemDto
    {
        public static readonly Expression<Func<TestSession, TestSessionListItemDto>> Selector = session =>
            new TestSessionListItemDto
            {
                Id = session.Id,
                Name = session.Name,
                State = session.State,
                CreatedAt = session.CreatedAt,
            };

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string State { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}