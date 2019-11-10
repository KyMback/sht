namespace SHT.Domain.Services.Exceptions
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
    }
}