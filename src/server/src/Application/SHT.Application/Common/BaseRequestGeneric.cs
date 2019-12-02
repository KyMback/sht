using JetBrains.Annotations;
using MediatR;

namespace SHT.Application.Common
{
#pragma warning disable SA1649
    public abstract class BaseRequest<TData, TResponse> : IRequest<TResponse>
    {
        public BaseRequest(TData data)
        {
            Data = data;
        }

        [NotNull]
        public TData Data { get; set; }
    }
#pragma warning restore SA1649
}