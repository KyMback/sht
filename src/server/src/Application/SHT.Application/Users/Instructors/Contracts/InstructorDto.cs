using System;
using System.Linq.Expressions;
using SHT.Domain.Models.Users;

namespace SHT.Application.Users.Instructors.Contracts
{
    public class InstructorDto
    {
        public static readonly Expression<Func<Instructor, InstructorDto>> Selector = instructor =>
            new InstructorDto
            {
                Email = instructor.Account.Email,
                Id = instructor.Id,
            };

        public Guid Id { get; set; }

        public string Email { get; set; }
    }
}