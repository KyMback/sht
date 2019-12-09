using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.Tests.Student.Questions;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.StudentQuestions.Answer
{
    [UsedImplicitly]
    internal class AnswerStudentQuestionHandler : IRequestHandler<AnswerStudentQuestionRequest>
    {
        private readonly IStudentQuestionService _studentQuestionService;
        private readonly IUnitOfWork _unitOfWork;

        public AnswerStudentQuestionHandler(
            IStudentQuestionService studentQuestionService,
            IUnitOfWork unitOfWork)
        {
            _studentQuestionService = studentQuestionService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AnswerStudentQuestionRequest request, CancellationToken cancellationToken)
        {
            var data = request.Data;
            await _studentQuestionService.Answer(data.QuestionId, data.Answer);
            await _unitOfWork.Commit();
            return Unit.Value;
        }
    }
}