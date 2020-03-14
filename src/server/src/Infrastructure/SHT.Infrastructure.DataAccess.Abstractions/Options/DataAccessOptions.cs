namespace SHT.Infrastructure.DataAccess.Abstractions.Options
{
    public class DataAccessOptions
    {
        public bool EnableLogging { get; set; }

        public bool EnableSensitiveDataLogging { get; set; }

        public bool EnableDetailedErrors { get; set; }

        public ConnectionsOptions ConnectionsOptions { get; set; }
    }
}