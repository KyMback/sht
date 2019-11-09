namespace SHT.Api.Web.Constants
{
    public static class HttpHeaders
    {
        /// <summary>
        ///     Header name used to pass Error code.
        /// </summary>
        public const string ErrorCode = "X-ERROR-CODE";

        /// <summary>
        ///     Header name used to pass Errors.
        /// </summary>
        public const string ErrorId = "X-ERROR-ID";

        /// <summary>
        /// Header name used to pass payload errors.
        /// </summary>
        public const string ErrorPayload = "X-ERROR-PAYLOAD";
    }
}