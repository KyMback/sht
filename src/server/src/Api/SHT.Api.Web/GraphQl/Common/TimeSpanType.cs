using System;
using System.Globalization;
using HotChocolate.Language;
using HotChocolate.Types;

namespace SHT.Api.Web.GraphQl.Common
{
    public class TimeSpanType : ScalarType
    {
        public TimeSpanType()
            : base("TimeSpan")
        {
        }

        public override Type ClrType => typeof(TimeSpan);

        public override bool IsInstanceOfType(IValueNode literal)
        {
            if (literal == null)
            {
                throw new ArgumentNullException(nameof(literal));
            }

            return literal is StringValueNode || literal is NullValueNode;
        }

        public override object ParseLiteral(IValueNode literal)
        {
            if (literal == null)
            {
                throw new ArgumentNullException(nameof(literal));
            }

            if (literal is NullValueNode)
            {
                return null;
            }

            if (literal is StringValueNode stringLiteral)
            {
                return TimeSpan.Parse(stringLiteral.Value, CultureInfo.InvariantCulture);
            }

            throw new ArgumentException(
                "The TimeSpanType can only parse string literals.",
                nameof(literal));
        }

        public override IValueNode ParseValue(object value)
        {
            if (value == null)
            {
                return new NullValueNode(null);
            }

            if (value is TimeSpan t)
            {
                return new StringValueNode(null, t.ToString("c", CultureInfo.InvariantCulture), false);
            }

            throw new ArgumentException(
                "The specified value has to be a TimeSpan in order to be parsed by the TimeSpanType.");
        }

        public override object Serialize(object value)
        {
            if (value == null)
            {
                return null;
            }

            if (value is TimeSpan t)
            {
                return t.ToString("c", CultureInfo.InvariantCulture);
            }

            throw new ArgumentException(
                "The specified value cannot be serialized by the TimeSpanType.");
        }

        public override bool TryDeserialize(object serialized, out object value)
        {
            if (serialized is null)
            {
                value = null;
                return true;
            }

            if (serialized is string s)
            {
                var result = TimeSpan.TryParse(s, out var ts);
                value = ts;
                return result;
            }

            value = null;
            return false;
        }
    }
}