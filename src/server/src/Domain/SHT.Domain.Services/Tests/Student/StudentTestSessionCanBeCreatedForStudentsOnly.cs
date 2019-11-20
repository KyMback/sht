using System.Collections.Generic;
using FluentValidation;
using SHT.Domain.Models.Users;

namespace SHT.Domain.Services.Tests.Student
{
    internal class StudentTestSessionCanBeCreatedForStudentsOnly : AbstractValidator<IEnumerable<UserType>>
    {
        public StudentTestSessionCanBeCreatedForStudentsOnly()
        {
            RuleFor(e => e).ForEach(e => e.Equal(UserType.Student));
        }
    }
}