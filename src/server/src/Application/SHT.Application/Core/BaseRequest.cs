using JetBrains.Annotations;
using MediatR;

namespace SHT.Application.Core
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