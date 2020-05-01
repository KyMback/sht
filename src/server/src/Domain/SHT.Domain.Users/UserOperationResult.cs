using System.Collections.Generic;

namespace SHT.Domain.Users
{
    public class UserOperationResult
    {
        public bool Succeeded { get; set; }

        public IReadOnlyCollection<string> Errors { get; set; }
    }
}