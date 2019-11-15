using System;
using FluentAssertions;
using FluentAssertions.Primitives;

namespace SHT.Tests.Integration.Extensions
{
    internal static class AssertionExtensions
    {
        public static AndConstraint<DateTimeAssertions> BeCloseToDateWithDefaultPrecision(
            this DateTimeAssertions data,
            DateTime expectedValue)
        {
            return data.BeCloseTo(expectedValue, TestFixtureConstants.MaxDiffForComparingDateTimes);
        }
    }
}