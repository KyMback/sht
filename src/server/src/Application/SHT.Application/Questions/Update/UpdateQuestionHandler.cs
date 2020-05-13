using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Questions.Templates;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.Common.ExecutionContext;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Questions.Update
{
    [UsedImplicitly]
    internal class UpdateQuestionHandler : IRequestHandler<UpdateQuestionRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IExecutionContextService _executionContextService;

        public UpdateQuestionHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IExecutionContextService executionContextService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _executionContextService = executionContextService;
        }

        public async Task<Unit> Handle(UpdateQuestionRequest request, CancellationToken cancellationToken)
        {
            var queryParams = new QuestionTemplateQueryParameters
            {
                Id = request.Id,
                IsReadOnly = false,
                CreatedById = _executionContextService.GetCurrentUserId(),
            };
            var question = await _unitOfWork.GetSingle(queryParams);
            _mapper.Map(request.Data, question);
            await _unitOfWork.Commit();

            return default;
        }
    }
}