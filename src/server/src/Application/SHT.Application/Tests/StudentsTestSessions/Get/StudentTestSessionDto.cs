using System.ComponentModel.DataAnnotations;
using SHT.Application.Common;

namespace SHT.Application.Tests.StudentsTestSessions.Get
{
    [ApiDataContract]
    public class StudentTestSessionDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Variant { get; set; }
    }
}