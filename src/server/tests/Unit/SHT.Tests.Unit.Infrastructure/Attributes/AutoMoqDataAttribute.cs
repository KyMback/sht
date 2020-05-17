using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using SHT.Tests.Unit.Infrastructure.AutoFixtureCustomizations;

namespace SHT.Tests.Unit.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(() => FixtureFactory())
        {
        }

        public AutoMoqDataAttribute(int skipParametersCount)
            : base(() => FixtureFactory(skipParametersCount))
        {
        }

        public AutoMoqDataAttribute(params Type[] customizations)
            : base(() => FixtureFactory(customizations))
        {
        }

        private static IFixture FixtureFactory(params Type[] customizations)
        {
            var fixture = new Fixture();
            ConfigureFixture(fixture, customizations);

            return fixture;
        }

        private static IFixture FixtureFactory(int skippedParametersCount)
        {
            IFixture fixture = FixtureFactory();

            fixture.Customizations.Add(new SkipMemberSpecimenBuilder(skippedParametersCount));
            return fixture;
        }

        private static void ConfigureFixture(Fixture fixture, IReadOnlyCollection<Type> customizations)
        {
            fixture.Customize(new AutoMoqCustomization());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));

            foreach (Type customization in customizations)
            {
                fixture.Customize(Activator.CreateInstance(customization) as ICustomization);
            }
        }
    }
}