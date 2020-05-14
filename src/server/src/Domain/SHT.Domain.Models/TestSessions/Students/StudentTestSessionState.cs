namespace SHT.Domain.Models.TestSessions.Students
{
    public static class StudentTestSessionState
    {
        public static readonly string Pending = nameof(Pending);

        public static readonly string Started = nameof(Started);

        public static readonly string Ended = nameof(Ended);

        public static readonly string Overdue = nameof(Ended);
    }
}