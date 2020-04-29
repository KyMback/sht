namespace SHT.Domain.Common.Exceptions
{
    public enum ErrorCode
    {
        UnhandledException = 0,

        Unauthenticated = 1,

        Unauthorized = 2,

        RouteNotFound = 3,

        ConcurrentModification = 4,

        DataIsInvalid = 5,

        LoginIsNotUniq = 6,

        InvalidUserType = 7,

        InvalidVariantName = 8,

        InvalidEmailConfirmationToken = 9,

        NotConfirmedEmail = 10,

        StudentTestSessionEnded = 11,
    }
}