using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Primitives;
using FluentAssertions.Specialized;
using SHT.Domain.Common.Exceptions;

namespace SHT.Tests.Unit.Infrastructure.Extensions
{
    public static class AssertionExtensions
    {
        public static async Task<AndConstraint<ObjectAssertions>> ThrowWithCode<TException>(
            this NonGenericAsyncFunctionAssertions functionAssertions, ErrorCode code)
            where TException : CodedException
        {
            var assertion = await functionAssertions.ThrowAsync<TException>();
            return assertion.And.Code.Should().Be(code);
        }

        public static async Task<AndConstraint<ObjectAssertions>> ThrowWithCode<TValue, TException>(
            this GenericAsyncFunctionAssertions<TValue> functionAssertions, ErrorCode code)
            where TException : CodedException
        {
            var assertion = await functionAssertions.ThrowAsync<TException>();
            return assertion.And.Code.Should().Be(code);
        }
    }
}
