using System;

namespace SHT.Application.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct)]
    public class ApiDataContractAttribute : Attribute
    {
    }
}