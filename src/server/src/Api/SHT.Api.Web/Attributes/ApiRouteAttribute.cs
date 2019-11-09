using System;
using Microsoft.AspNetCore.Mvc;
using SHT.Api.Web.Constants;

namespace SHT.Api.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiRouteAttribute : RouteAttribute
    {
        public ApiRouteAttribute()
            : this("[controller]")
        {
        }

        public ApiRouteAttribute(string route)
            : base($"{RoutesConstants.Api}/{route}")
        {
        }
    }
}