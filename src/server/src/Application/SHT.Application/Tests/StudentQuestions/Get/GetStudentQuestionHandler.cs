using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.Tests.Student.Questions;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.StudentQuestions.Get
{
    [UsedImplicitly]
    internal class GetStudentQuestionHandler : IRequestHandler<GetStudentQuestionRequest, StudentQuestionDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public GetStudentQuestionHandler(
            IUnitOfWork unitOfWork,
            IExecutionContextAccessor executionContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _executionContextAccessor = executionContextAccessor;
        }

        public Task<StudentQuestionDto> Handle(GetStudentQuestionRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new StudentQuestionQueryParameters
            {
                Id = request.Id,
                StudentId = _executionContextAccessor.GetCurrentUserId(),
            };

            return _unitOfWork.GetSingle(queryParameters, question => new StudentQuestionDto
            {
                Answer = question.Answer,
                Id = question.Id,
                Number = question.Number,
                Text = question.Text,
                Type = question.Type,
            });
        }
    }
}