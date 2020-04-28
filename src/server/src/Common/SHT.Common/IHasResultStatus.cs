using System.Collections.Generic;

namespace SHT.Common
{
    public interface IHasResultStatus
    {
        bool Succeeded { get; }

        IReadOnlyCollection<string> Errors { get; set; }
    }
}
