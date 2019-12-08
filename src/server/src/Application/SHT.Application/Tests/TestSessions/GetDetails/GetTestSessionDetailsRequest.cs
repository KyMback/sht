using System;
using MediatR;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Application.Tests.TestSessions.GetDetails
{
    public class GetTestSessionDetailsRequest : IRequest<TestSessionDetailsDto>
    {
        public GetTestSessionDetailsRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}