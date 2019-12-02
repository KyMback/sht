using System;

namespace SHT.Application.Common
{
    [ApiDataContract]
    public class CreatedEntityResponse
    {
        public CreatedEntityResponse(Guid id)
        {
            Id = id;
        }

        public CreatedEntityResponse()
        {
        }

        public Guid Id { get; set; }
    }
}