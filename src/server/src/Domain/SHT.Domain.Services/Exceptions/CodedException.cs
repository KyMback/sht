using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SHT.Domain.Services.Exceptions
{
    public class CodedException : Exception
    {
        public CodedException(ErrorCode code)
            : this(code, default(string))
        {
        }

        public CodedException(ErrorCode code, object payload)
            : this(code)
        {
            Payload = payload;
        }

        protected CodedException(ErrorCode code, string message)
            : this(code, message, null)
        {
        }

        protected CodedException(ErrorCode code, string message, object payload)
            : this(code, message)
        {
            Payload = payload;
        }

        protected CodedException(ErrorCode code, Exception innerException)
            : this(code, null, innerException)
        {
        }

        protected CodedException(ErrorCode code, string message, Exception innerException)
            : base(message, innerException)
        {
            Code = code;
        }

        protected CodedException(
            ErrorCode code,
            string message,
            Exception innerException,
            IEnumerable<string> errorList)
            : this(code, message, innerException)
        {
            Code = code;
            ErrorList = errorList;
        }

        protected CodedException()
        {
        }

        protected CodedException(string message)
            : base(message)
        {
        }

        protected CodedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        ///     Gets error category.
        /// </summary>
        public ErrorCode Code { get; }

        /// <summary>
        ///     Gets errors as codes.
        /// </summary>
        public IEnumerable<string> ErrorList { get; }

        /// <summary>
        ///     Gets payload for error.
        /// </summary>
        public object Payload { get; }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(Code), Code);
            info.AddValue(nameof(ErrorList), ErrorList);
            info.AddValue(nameof(Payload), Payload);
        }
    }
}