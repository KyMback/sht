using System;
using System.Threading.Tasks;
using MediatR;
using SHT.Application.Tests.StudentsTestSessions.FinalizeStudentsTestSessionsAction.Single;
using SHT.Infrastructure.BackgroundProcess;

namespace SHT.BackgroundProcess.Jobs.Jobs
{
    [Job(JobNames.FinalizeStudentTestSessionJob)]
    public class FinalizeStudentTestSessionJob : BaseJob<FinalizeStudentTestSessionRequest>
    {
        private readonly IMediator _mediator;

        public FinalizeStudentTestSessionJob(IServiceProvider serviceProvider, IMediator mediator)
            : base(serviceProvider)
        {
            _mediator = mediator;
        }

        protected override Task ExecuteInternal(FinalizeStudentTestSessionRequest param)
        {
            return _mediator.Send(param);
        }
    }
}