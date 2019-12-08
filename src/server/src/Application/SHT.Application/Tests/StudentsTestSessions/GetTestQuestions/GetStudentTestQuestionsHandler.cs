using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.Tests.Student.Questions;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.StudentsTestSessions.GetTestQuestions
{
    [UsedImplicitly]
    internal class GetStudentTestQuestionsHandler :
        IRequestHandler<GetStudentTestQuestionsRequest, IReadOnlyCollection<StudentTestQuestionListItemDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public GetStudentTestQuestionsHandler(
            IUnitOfWork unitOfWork,
            IExecutionContextAccessor executionContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _executionContextAccessor = executionContextAccessor;
        }

        public Task<IReadOnlyCollection<StudentTestQuestionListItemDto>> Handle(
            GetStudentTestQuestionsRequest request,
            CancellationToken cancellationToken)
        {
            var queryParameters = new StudentQuestionQueryParameters
            {
                StudentTestSessionId = request.StudentSessionId,
                StudentId = _executionContextAccessor.GetCurrentUserId(),
                OrderAscByNumber = true,
            };

            return _unitOfWork.GetAll(queryParameters, question => new StudentTestQuestionListItemDto
            {
                Id = question.Id,
                Number = question.Number,
                Type = question.Type,
                IsAnswered = !string.IsNullOrWhiteSpace(question.Answer),
            });
        }
    }
}