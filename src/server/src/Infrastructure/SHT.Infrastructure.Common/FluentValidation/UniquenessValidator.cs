using System;
using System.Collections.Generic;
using FluentValidation;

namespace SHT.Infrastructure.Common.FluentValidation
{
    public class UniquenessValidator<TData, TKey> : AbstractValidator<IEnumerable<TData>>
    {
        public UniquenessValidator(Func<TData, TKey> keySelector)
        {
            RuleFor(e => e).Must(items =>
            {
                var set = new HashSet<TKey>();

                foreach (var item in items)
                {
                    if (set.Contains(keySelector(item)))
                    {
                        return false;
                    }

                    set.Add(keySelector(item));
                }

                return true;
            });
        }
    }
}