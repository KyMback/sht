using System;
using System.Linq.Expressions;
using SHT.Domain.Models.Users;

namespace SHT.Application.Users.Students.Contracts
{
    public class StudentProfileDto
    {
        public static readonly Expression<Func<Student, StudentProfileDto>> Selector = student =>
            new StudentProfileDto
            {
                Email = student.Account.Email,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Group = student.Group,
            };

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Group { get; set; }
    }
}