using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace SHT.Infrastructure.Common.Extensions
{
    public static class FluentValidatorExecutionExtensions
    {
        public static void ThrowIfInvalid(this IEnumerable<IValidator> validators, object parameter)
        {
            var failures = validators
                .Select(validator => validator.Validate(parameter))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();

            if (failures.Any())
            {
                throw new Exceptions.ValidationException(failures.Select(f => f.ErrorCode));
            }
        }
    }
}