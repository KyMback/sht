using System;
using System.Linq.Expressions;
using SHT.Domain.Models.Users;

namespace SHT.Application.Users.Instructors.Contracts
{
    public class InstructorProfileDto
    {
        public static readonly Expression<Func<Instructor, InstructorProfileDto>> Selector = instructor =>
            new InstructorProfileDto
            {
                Email = instructor.Account.Email,
            };

        public string Email { get; set; }
    }
}