namespace SHT.Infrastructure.Services.Abstractions
{
    public class EmailOptions
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string FromAddress { get; set; }
    }
}