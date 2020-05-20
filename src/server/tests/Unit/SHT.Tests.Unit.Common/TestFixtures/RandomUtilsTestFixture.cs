using System.Linq;
using FluentAssertions;
using SHT.Common.Utils;
using SHT.Tests.Unit.Infrastructure.Attributes;
using Xunit;

namespace SHT.Tests.Unit.Common.TestFixtures
{
    public class RandomUtilsTestFixture
    {
        [Theory]
        [InlineAutoMoqData(1, 10)]
        [InlineAutoMoqData(1, 100)]
        [InlineAutoMoqData(-100, 100)]
        public void GenerateRandomSequence_GeneralFlow_RandomSequence(int from, int count)
        {
            // Arrange & Act
            var result = RandomUtils.GenerateRandomSequence(from, count);

            // Assert
            result.Should().BeEquivalentTo(Enumerable.Range(from, count));
            result.Should().NotBeInAscendingOrder();
            result.Should().NotBeInDescendingOrder();
        }
    }
}