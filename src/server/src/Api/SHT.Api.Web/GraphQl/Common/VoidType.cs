using System;
using HotChocolate.Language;
using HotChocolate.Types;

namespace SHT.Api.Web.GraphQl.Common
{
    public class VoidType : ScalarType
    {
        public VoidType()
            : base("VoidType")
        {
        }

        public override Type ClrType { get; } = typeof(object);

        public override bool IsInstanceOfType(IValueNode literal)
        {
            throw new NotImplementedException();
        }

        public override object ParseLiteral(IValueNode literal)
        {
            throw new NotImplementedException();
        }

        public override IValueNode ParseValue(object value)
        {
            throw new NotImplementedException();
        }

        public override object Serialize(object value)
        {
            return null;
        }

        public override bool TryDeserialize(object serialized, out object value)
        {
            throw new NotImplementedException();
        }
    }
}