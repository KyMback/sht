using System;
using System.Reflection;

namespace SHT.Api.Web.Services
{
    internal class AssemblyProvider
    {
        /// <summary>
        ///     Gets version of current assembly.
        /// </summary>
        /// <returns>Assembly version.</returns>
        public static string GetVersion()
        {
            return GetEntryAssemblyOrThrow()
                       .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ??
                   GetEntryAssemblyOrThrow().GetName().Version.ToString();
        }

        /// <summary>
        ///     Gets Product Name of current assembly.
        /// </summary>
        /// <returns>Assembly Product Name.</returns>
        public static string GetProductName()
        {
            return GetEntryAssemblyOrThrow().GetCustomAttribute<AssemblyProductAttribute>().Product;
        }

        /// <summary>
        ///     Gets Description of current assembly.
        /// </summary>
        /// <returns>Assembly Description.</returns>
        public static string GetDescription()
        {
            return GetEntryAssemblyOrThrow().GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;
        }

        private static Assembly GetEntryAssemblyOrThrow()
        {
            return Assembly.GetEntryAssembly() ?? throw new NullReferenceException();
        }
    }
}