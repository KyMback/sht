using FluentValidation;
using SHT.Application.Users.Students.Contracts;
using SHT.Domain.Models;

namespace SHT.Application.Users.Students.UpdateProfile
{
    public class StudentProfileModificationDtoValidator : AbstractValidator<StudentProfileModificationDto>
    {
        public StudentProfileModificationDtoValidator()
        {
            RuleFor(e => e.Group).NotEmpty().MaximumLength(LengthConstants.Small);
            RuleFor(e => e.FirstName).NotEmpty().MaximumLength(LengthConstants.Small);
            RuleFor(e => e.LastName).NotEmpty().MaximumLength(LengthConstants.Small);
        }
    }
}