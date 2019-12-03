using System.Collections.Generic;

namespace SHT.Domain.Services.Users
{
    public class UserOperationResult
    {
        public bool Succeeded { get; set; }

        public IReadOnlyCollection<string> Errors { get; set; }
    }
}