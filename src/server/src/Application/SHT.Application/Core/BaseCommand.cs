using MediatR;

namespace SHT.Application.Core
{
    public abstract class BaseCommand<TData> : IRequest
    {
        public BaseCommand(TData data)
        {
            Data = data;
        }

        public TData Data { get; set; }
    }
}