using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Infrastructure.Common.Localization;

namespace SHT.Application.Users.Accounts.SetCulture
{
    [UsedImplicitly]
    internal class SetCultureHandler : IRequestHandler<SetCultureRequest>
    {
        private readonly ILocalizationManagementService _localizationManagementService;

        public SetCultureHandler(ILocalizationManagementService localizationManagementService)
        {
            _localizationManagementService = localizationManagementService;
        }

        public async Task<Unit> Handle(SetCultureRequest request, CancellationToken cancellationToken)
        {
            await _localizationManagementService.SetCulture(new CultureInfo(request.Culture));
            return default;
        }
    }
}