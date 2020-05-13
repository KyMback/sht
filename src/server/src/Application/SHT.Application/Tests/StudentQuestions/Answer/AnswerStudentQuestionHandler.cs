using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.Student.Questions;

namespace SHT.Application.Tests.StudentQuestions.Answer
{
    [UsedImplicitly]
    internal class AnswerStudentQuestionHandler : IRequestHandler<AnswerStudentQuestionRequest>
    {
        private readonly IStudentQuestionService _studentQuestionService;
        private readonly IMapper _mapper;

        public AnswerStudentQuestionHandler(IStudentQuestionService studentQuestionService, IMapper mapper)
        {
            _studentQuestionService = studentQuestionService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AnswerStudentQuestionRequest request, CancellationToken cancellationToken)
        {
            var answer = _mapper.Map<QuestionGenericAnswer>(request.Data);
            await _studentQuestionService.Answer(request.Data.QuestionId, answer);
            return default;
        }
    }
}