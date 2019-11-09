using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SHT.Infrastructure.Common.Exceptions
{
    public abstract class BusinessException : Exception
    {
        protected BusinessException(object payload)
        {
            Payload = payload;
        }

        protected BusinessException(string message, object payload)
            : this(message)
        {
            Payload = payload;
        }

        protected BusinessException(Exception innerException)
            : this(null, innerException)
        {
        }

        protected BusinessException(string message, Exception innerException, IEnumerable<string> errorList)
            : this(message, innerException)
        {
            ErrorList = errorList;
        }

        protected BusinessException(IEnumerable<string> errorList)
            : this(default, default, errorList)
        {
        }

        protected BusinessException()
        {
        }

        protected BusinessException(string message)
            : base(message)
        {
        }

        protected BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public IEnumerable<string> ErrorList { get; }

        public object Payload { get; }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(ErrorList), ErrorList);
            info.AddValue(nameof(Payload), Payload);
        }
    }
}