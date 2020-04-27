using MediatR;

namespace SHT.Application.Users.Accounts.SetCulture
{
    public class SetCultureRequest : IRequest
    {
        public SetCultureRequest(string culture)
        {
            Culture = culture;
        }

        public string Culture { get; set; }
    }
}