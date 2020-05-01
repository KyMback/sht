using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Users;

namespace SHT.Application.Users.Accounts.SignIn
{
    [UsedImplicitly]
    internal class SignInHandler : IRequestHandler<SignInRequest, SignInResponse>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public SignInHandler(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public async Task<SignInResponse> Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.SignIn(_mapper.Map<LoginData>(request.Data));

            return new SignInResponse
            {
                Succeeded = result,
            };
        }
    }
}