using MediatR;

namespace SHT.Application.Core
{
#pragma warning disable SA1649
    public abstract class BaseCommand<TData, TResponse> : IRequest<TResponse>
    {
        public BaseCommand(TData dataDto)
        {
            DataDto = dataDto;
        }

        public TData DataDto { get; set; }
    }
#pragma warning restore SA1649
}