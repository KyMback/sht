using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Users;
using SHT.Infrastructure.Common.ExecutionContext;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Users.Students.UpdateProfile
{
    [UsedImplicitly]
    internal class UpdateStudentProfileHandler : IRequestHandler<UpdateStudentProfileRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IExecutionContextService _executionContextService;

        public UpdateStudentProfileHandler(IUnitOfWork unitOfWork, IMapper mapper, IExecutionContextService executionContextService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _executionContextService = executionContextService;
        }

        public async Task<Unit> Handle(UpdateStudentProfileRequest request, CancellationToken cancellationToken)
        {
            var queryParams = new StudentQueryParameters
            {
                Id = _executionContextService.GetCurrentUserId(),
                IsReadOnly = false,
            };

            var student = await _unitOfWork.GetSingle(queryParams);
            _mapper.Map(request.Data, student);
            await _unitOfWork.Update(student);
            await _unitOfWork.Commit();

            return default;
        }
    }
}