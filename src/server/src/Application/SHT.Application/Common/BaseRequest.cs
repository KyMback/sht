using JetBrains.Annotations;
using MediatR;

namespace SHT.Application.Common
{
    public abstract class BaseRequest<TData> : IRequest
    {
        public BaseRequest(TData data)
        {
            Data = data;
        }

        [NotNull]
        public TData Data { get; set; }
    }
}