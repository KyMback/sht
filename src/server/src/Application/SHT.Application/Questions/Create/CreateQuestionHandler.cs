using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Common;
using SHT.Domain.Models.Questions;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Questions.Create
{
    [UsedImplicitly]
    internal class CreateQuestionHandler : IRequestHandler<CreateQuestionRequest, CreatedEntityResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateQuestionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreatedEntityResponse> Handle(CreateQuestionRequest request, CancellationToken cancellationToken)
        {
            var questionTemplate = _mapper.Map<QuestionTemplate>(request.Data);
            var created = await _unitOfWork.Add(questionTemplate);
            await _unitOfWork.Commit();

            return new CreatedEntityResponse(created.Id);
        }
    }
}