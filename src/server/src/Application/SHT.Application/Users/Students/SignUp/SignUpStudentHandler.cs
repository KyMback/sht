using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.Users.Students;

namespace SHT.Application.Users.Students.SignUp
{
    [UsedImplicitly]
    internal class SignUpStudentHandler : IRequestHandler<SignUpStudentRequest>
    {
        private readonly IStudentAccountService _studentAccountService;
        private readonly IMapper _mapper;

        public SignUpStudentHandler(
            IStudentAccountService studentAccountService,
            IMapper mapper)
        {
            _studentAccountService = studentAccountService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(
            SignUpStudentRequest request,
            CancellationToken cancellationToken)
        {
            await _studentAccountService.Create(_mapper.Map<StudentCreationData>(request.Data));
            return default;
        }
    }
}