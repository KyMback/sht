using JetBrains.Annotations;
using MediatR;

namespace SHT.Application.Core
{
#pragma warning disable SA1649
    public abstract class BaseRequest<TData, TResponse> : IRequest<TResponse>
    {
        public BaseRequest(TData dataDto)
        {
            DataDto = dataDto;
        }

        [NotNull]
        public TData DataDto { get; set; }
    }
#pragma warning restore SA1649
}