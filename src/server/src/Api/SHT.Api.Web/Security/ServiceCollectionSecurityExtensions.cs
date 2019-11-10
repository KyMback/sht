using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SHT.Api.Web.Extensions;
using SHT.Api.Web.Security.Constants;
using SHT.Api.Web.Security.Options;
using SHT.Domain.Models.Users;

namespace SHT.Api.Web.Security
{
    internal static class ServiceCollectionSecurityExtensions
    {
        public static IServiceCollection AddCustomSecurity(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection
                .AddIdentityCore<User>(options =>
                {
                    var cfg = configuration.GetTypedSection<AuthOptions>("AuthOptions").PasswordOptions;
                    options.Password.RequireLowercase = cfg.RequireLowercase;
                    options.Password.RequireUppercase = cfg.RequireUppercase;
                    options.Password.RequireNonAlphanumeric = cfg.RequireNonAlphanumeric;
                    options.Password.RequiredLength = cfg.RequiredLength;
                })
                .AddUserStore<UserStore>()
                .AddUserManager<UserManager<User>>()
                .AddSignInManager<SignInManager<User>>();

            serviceCollection
                .AddAuthorization(options =>
                {
                    options.AddPolicy(
                        AuthorizationPolicyNames.InstructorsOnly,
                        builder => builder.RequireClaim(
                            CustomClaimTypes.UserType,
                            UserType.Instructor.ToString("G")));
                    options.AddPolicy(
                        AuthorizationPolicyNames.StudentsOnly,
                        builder => builder.RequireClaim(
                            CustomClaimTypes.UserType,
                            UserType.Student.ToString("G")));
                })
                .AddAuthentication(options => options.DefaultScheme = AuthenticationDefaults.AuthenticationScheme)
                .AddCookie(AuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.Cookie.Name = AuthenticationCookieDefaults.CookieName;
                    options.Cookie.HttpOnly = AuthenticationCookieDefaults.IsHttpOnly;
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnRedirectToAccessDenied = context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                            return Task.CompletedTask;
                        },
                        OnRedirectToLogin = context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            return Task.CompletedTask;
                        },
                    };
                });

            serviceCollection.AddScoped<IUserClaimsPrincipalFactory<User>, CustomUserClaimsPrincipalFactory>();

            return serviceCollection;
        }
    }
}