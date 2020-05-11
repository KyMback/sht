using FluentValidation;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Application.Tests.TestSessions.Common
{
    internal class TestSessionVariantDataDtoValidator : AbstractValidator<TestSessionVariantDto>
    {
        public TestSessionVariantDataDtoValidator()
        {
            RuleFor(e => e.Name).NotEmpty();
        }
    }
}