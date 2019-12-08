using System;
using System.Collections.Generic;
using MediatR;

namespace SHT.Application.Tests.StudentsTestSessions.GetAvailableStateTransitions
{
    public class GetStudentTestSessionAvailableStateTransitionsRequest : IRequest<IEnumerable<string>>
    {
        public GetStudentTestSessionAvailableStateTransitionsRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}