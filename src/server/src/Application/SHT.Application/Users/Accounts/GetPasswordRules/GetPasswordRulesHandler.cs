using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.Users;

namespace SHT.Application.Users.Accounts.GetPasswordRules
{
    [UsedImplicitly]
    internal class GetPasswordRulesHandler : IRequestHandler<GetPasswordRulesRequest, PasswordRulesDto>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public GetPasswordRulesHandler(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public Task<PasswordRulesDto> Handle(GetPasswordRulesRequest request, CancellationToken cancellationToken)
        {
            PasswordRules rules = _authenticationService.GetPasswordRules();
            return Task.FromResult(_mapper.Map<PasswordRulesDto>(rules));
        }
    }
}