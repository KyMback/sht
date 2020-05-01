using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Questions.Templates;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Questions.Update
{
    [UsedImplicitly]
    internal class UpdateQuestionHandler : IRequestHandler<UpdateQuestionRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public UpdateQuestionHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IExecutionContextAccessor executionContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _executionContextAccessor = executionContextAccessor;
        }

        public async Task<Unit> Handle(UpdateQuestionRequest request, CancellationToken cancellationToken)
        {
            var queryParams = new QuestionTemplateQueryParameters
            {
                Id = request.Id,
                IsReadOnly = false,
                CreatedById = _executionContextAccessor.GetCurrentUserId(),
            };
            var question = await _unitOfWork.GetSingle(queryParams);
            _mapper.Map(request.Data, question);
            await _unitOfWork.Commit();

            return default;
        }
    }
}