using MediatR;

namespace SHT.Application.Core
{
    public class BaseCommand<TData> : IRequest
    {
        public BaseCommand(TData data)
        {
            Data = data;
        }

        public TData Data { get; set; }
    }
}