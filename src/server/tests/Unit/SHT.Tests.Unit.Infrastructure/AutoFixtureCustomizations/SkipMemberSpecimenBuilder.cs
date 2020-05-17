using System.Linq;
using System.Reflection;
using AutoFixture.Kernel;
using Xunit.Sdk;

namespace SHT.Tests.Unit.Infrastructure.AutoFixtureCustomizations
{
    public class SkipMemberSpecimenBuilder : ISpecimenBuilder
    {
        private readonly int _skippedParametersCount;

        public SkipMemberSpecimenBuilder(int skippedParametersCount)
        {
            _skippedParametersCount = skippedParametersCount;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as ParameterInfo;
            if (pi == null)
            {
                return new NoSpecimen();
            }

            if (pi.Position < _skippedParametersCount && pi.Member.GetCustomAttributes<DataAttribute>().Any())
            {
                return null;
            }

            return new NoSpecimen();
        }
    }
}
