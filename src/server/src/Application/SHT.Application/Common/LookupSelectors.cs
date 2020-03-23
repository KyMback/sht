using System;
using System.Linq.Expressions;
using SHT.Domain.Models.Tests;

namespace SHT.Application.Common
{
    public static class LookupSelectors
    {
        public static readonly Expression<Func<TestVariant, Lookup>> VariantSelector =
            variant => new Lookup(variant.Name, variant.Id.ToString());
    }
}