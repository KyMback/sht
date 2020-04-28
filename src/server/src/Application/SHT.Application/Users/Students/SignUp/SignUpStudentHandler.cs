using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.Users;
using SHT.Domain.Services.Users.Students;

namespace SHT.Application.Users.Students.SignUp
{
    [UsedImplicitly]
    internal class SignUpStudentHandler : IRequestHandler<SignUpStudentRequest>
    {
        private readonly IRegistrationValidationService _registrationValidationService;
        private readonly IStudentAccountService _studentAccountService;
        private readonly IMapper _mapper;

        public SignUpStudentHandler(
            IRegistrationValidationService registrationValidationService,
            IStudentAccountService studentAccountService,
            IMapper mapper)
        {
            _registrationValidationService = registrationValidationService;
            _studentAccountService = studentAccountService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(
            SignUpStudentRequest request,
            CancellationToken cancellationToken)
        {
            var data = request.Data;
            await _registrationValidationService.TrowsIfEmailIsNotUniq(data.Email);
            await _studentAccountService.Create(_mapper.Map<StudentCreationData>(data));

            return default;
        }
    }
}