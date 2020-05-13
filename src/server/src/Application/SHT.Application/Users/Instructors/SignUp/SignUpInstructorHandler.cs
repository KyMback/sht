using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Users.Instructors;

namespace SHT.Application.Users.Instructors.SignUp
{
    [UsedImplicitly]
    internal class SignUpInstructorHandler : IRequestHandler<SignUpInstructorRequest>
    {
        private readonly IInstructorAccountService _instructorAccountService;
        private readonly IMapper _mapper;

        public SignUpInstructorHandler(IInstructorAccountService instructorAccountService, IMapper mapper)
        {
            _instructorAccountService = instructorAccountService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(SignUpInstructorRequest request, CancellationToken cancellationToken)
        {
            await _instructorAccountService.Create(_mapper.Map<InstructorCreationData>(request.Data));
            return default;
        }
    }
}