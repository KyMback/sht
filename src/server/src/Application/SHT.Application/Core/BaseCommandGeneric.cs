using MediatR;

namespace SHT.Application.Core
{
#pragma warning disable SA1649
    public class BaseCommand<TData, TResponse> : IRequest<TResponse>
    {
        public BaseCommand(TData data)
        {
            Data = data;
        }

        public TData Data { get; set; }
    }
#pragma warning restore SA1649
}