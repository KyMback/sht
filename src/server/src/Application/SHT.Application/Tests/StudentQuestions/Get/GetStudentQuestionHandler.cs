using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.Tests.Student.Questions;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.StudentQuestions.Get
{
    [UsedImplicitly]
    internal class GetStudentQuestionHandler : IRequestHandler<GetStudentQuestionRequest, StudentQuestionDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStudentQuestionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<StudentQuestionDto> Handle(GetStudentQuestionRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new StudentQuestionQueryParameters
            {
                Id = request.Id,
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