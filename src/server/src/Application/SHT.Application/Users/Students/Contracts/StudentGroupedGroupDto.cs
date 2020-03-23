using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SHT.Application.Common;

namespace SHT.Application.Users.Students.Contracts
{
    [ApiDataContract]
    public class StudentGroupedGroupDto
    {
        [Required]
        public string GroupName { get; set; }

        [Required]
        public IReadOnlyCollection<Guid> StudentsIds { get; set; }
    }
}