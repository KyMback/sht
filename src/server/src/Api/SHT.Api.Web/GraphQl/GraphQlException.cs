using System;
using System.Collections.Generic;
using System.Linq;
using HotChocolate;

namespace SHT.Api.Web.GraphQl
{
    public class GraphQlException : Exception
    {
        public GraphQlException(string message)
            : base(message)
        {
        }

        public GraphQlException()
        {
        }

        public GraphQlException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public GraphQlException(IReadOnlyCollection<IError> errors)
        {
            Errors = errors;
        }

        public IReadOnlyCollection<IError> Errors { get; set; }

        public override string ToString()
        {
            var errors = string.Join(
                Environment.NewLine,
                Errors.Select(e =>
                    e.Message + (e.Exception != null ? Environment.NewLine + e.Exception : string.Empty)));
            return errors + Environment.NewLine + base.ToString();
        }
    }
}