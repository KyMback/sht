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

        public GraphQlException(Exception innerException)
            : this(default, innerException)
        {
        }

        public override string ToString()
        {
            return Message + Environment.NewLine + InnerException;
        }
    }
}