using System;
using System.Threading.Tasks;
using MediatR;
using SHT.Application.Tests.StudentsTestSessions.FinalizeStudentsTestSessionsAction.Batch;

namespace SHT.BackgroundProcess.Jobs.RecurringJobs
{
    public class FinalizeStudentsTestSessionsJob : BaseRecurringJob
    {
        private readonly IMediator _mediator;

        public FinalizeStudentsTestSessionsJob(IServiceProvider serviceProvider, IMediator mediator)
            : base(serviceProvider)
        {
            _mediator = mediator;
        }

        protected override Task ExecuteInternal()
        {
            return _mediator.Send(new FinalizeStudentsTestSessionsRequest());
        }
    }
}