using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace SHT.Tests.Unit.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class MemberAutoMoqDataAttribute : DataAttribute
    {
        private readonly DataAttribute _baseAttribute;

        public MemberAutoMoqDataAttribute(string memberName, params object[] parameters)
            : this(new MemberDataAttribute(memberName, parameters))
        {
        }

        private MemberAutoMoqDataAttribute(DataAttribute baseAttribute)
        {
            _baseAttribute = baseAttribute;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
            {
                throw new ArgumentNullException(paramName: nameof(testMethod));
            }

            List<object[]> data = _baseAttribute.GetData(testMethod).ToList();
            var autoDataAttribute = new AutoMoqDataAttribute(data.Select(datum => datum.Length).Max());

            foreach (object[] datum in data)
            {
                object[] autoData = autoDataAttribute.GetData(testMethod).ToArray()[0];

                for (var i = 0; i < datum.Length; i++)
                {
                    autoData[i] = datum[i];
                }

                yield return autoData;
            }
        }
    }
}
