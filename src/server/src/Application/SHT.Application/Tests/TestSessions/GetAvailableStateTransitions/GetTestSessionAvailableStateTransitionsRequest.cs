using System;
using System.Collections.Generic;
using MediatR;

namespace SHT.Application.Tests.TestSessions.GetAvailableStateTransitions
{
    public class GetTestSessionAvailableStateTransitionsRequest : IRequest<IReadOnlyCollection<string>>
    {
        public GetTestSessionAvailableStateTransitionsRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}