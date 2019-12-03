namespace SHT.Api.Web.Constants
{
    public static class RoutesConstants
    {
        /// <summary>
        ///     Represents API route prefix.
        /// </summary>
        public const string Api = "/api";

        /// <summary>
        ///     Swagger JSON documentation route.
        /// </summary>
        public const string SwaggerJsonRoute = "/swagger";

        /// <summary>
        ///     Swagger UI route.
        /// </summary>
        /// <remarks>Set the Swagger UI to render at '/'.</remarks>
        public static readonly string SwaggerUiRoute = "/swagger";

        /// <summary>
        ///     Swagger UI start page route.
        /// </summary>
        public static readonly string SwaggerUiStartPageRoute = $"{SwaggerUiRoute}/index.html";

        public static readonly string EmailConfirmation = "email-confirmation";
    }
}