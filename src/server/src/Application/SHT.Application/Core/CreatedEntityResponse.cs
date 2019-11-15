using System;

namespace SHT.Application.Core
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