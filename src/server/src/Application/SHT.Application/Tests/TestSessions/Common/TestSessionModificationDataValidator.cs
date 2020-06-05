using System;
using FluentValidation;
using SHT.Application.Tests.TestSessions.Contracts.Edit;
using SHT.Domain.Models;
using SHT.Infrastructure.Common.FluentValidation;

namespace SHT.Application.Tests.TestSessions.Common
{
    internal class TestSessionModificationDataValidator : AbstractValidator<TestSessionModificationData>
    {
        public TestSessionModificationDataValidator()
        {
            RuleFor(e => e.StudentTestDuration).GreaterThan(TimeSpan.Zero);
            RuleFor(e => e.Name).NotEmpty().MaximumLength(LengthConstants.Medium);
            RuleFor(e => e.StudentsIds).NotNull();
            RuleFor(e => e.Variants).NotNull().SetValidator(new UniquenessValidator<TestSessionVariantModificationData, string>(data => data.Name));
            RuleForEach(e => e.Variants).NotNull().SetValidator(new TestSessionVariantModificationDataValidator());
        }
    }
}