using System;

namespace SHT.Application.Common
{
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