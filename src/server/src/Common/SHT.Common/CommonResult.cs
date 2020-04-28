using System.Collections.Generic;

namespace SHT.Common
{
    public class CommonResult : IHasResultStatus
    {
        public CommonResult(bool succeeded, IReadOnlyCollection<string> errors = default)
        {
            Succeeded = succeeded;
            Errors = errors;
        }

        public CommonResult()
        {
        }

        public bool Succeeded { get; }

        public IReadOnlyCollection<string> Errors { get; set; }

        public static CommonResult Success() => new CommonResult(true);

        public static CommonResult Fail(IReadOnlyCollection<string> errors = default) =>
            new CommonResult(false, errors);
    }
}
