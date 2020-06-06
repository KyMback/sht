using FluentValidation;

namespace SHT.Application.Users.Students.UpdateProfile
{
    public class UpdateStudentProfileRequestValidator : AbstractValidator<UpdateStudentProfileRequest>
    {
        public UpdateStudentProfileRequestValidator()
        {
            RuleFor(e => e.Data).SetValidator(new StudentProfileModificationDtoValidator());
        }
    }
}