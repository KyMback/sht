using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Tests.StudentQuestions.Contracts;
using SHT.Domain.Services.Student.Questions;
using SHT.Infrastructure.Common;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.QueryParameters.IQueryProvider;

namespace SHT.Application.Tests.StudentQuestions.GetAll
{
    [UsedImplicitly]
    internal class GetAllStudentTestQuestionsHandler :
        IRequestHandler<GetAllStudentTestQuestionsRequest, IQueryable<StudentTestQuestionDto>>
    {
        private readonly IExecutionContextAccessor _executionContextAccessor;
        private readonly IQueryProvider _queryProvider;

        public GetAllStudentTestQuestionsHandler(
            IExecutionContextAccessor executionContextAccessor,
            IQueryProvider queryProvider)
        {
            _executionContextAccessor = executionContextAccessor;
            _queryProvider = queryProvider;
        }

        public Task<IQueryable<StudentTestQuestionDto>> Handle(
            GetAllStudentTestQuestionsRequest request,
            CancellationToken cancellationToken)
        {
            var queryParameters = new StudentQuestionQueryParameters
            {
                StudentId = _executionContextAccessor.GetCurrentUserId(),
            };

            return Task.FromResult(_queryProvider.Queryable(queryParameters).Select(StudentTestQuestionDto.Selector));
        }
    }
}