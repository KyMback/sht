using System;

namespace SHT.Application.Common
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct)]
    public class ApiDataContractAttribute : Attribute
    {
    }
}