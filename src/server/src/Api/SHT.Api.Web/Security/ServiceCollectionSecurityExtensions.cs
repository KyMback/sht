using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SHT.Api.Web.Security.Constants;
using SHT.Api.Web.Security.Services;
using SHT.Domain.Models.Users;
using SHT.Domain.Services.Users;

namespace SHT.Api.Web.Security
{
    internal static class ServiceCollectionSecurityExtensions
    {
        public static IServiceCollection AddCustomSecurity(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection
                .AddIdentityCore<Account>()
                .AddUserStore<UserStore>()
                .AddUserManager<UserManager<Account>>()
                .AddSignInManager<SignInManager<Account>>();

            serviceCollection
                .AddScoped<IUserManagementService<Account>, UserManagementService<Account>>()
                .AddScoped<EmailConfirmationTokenProvider<Account>>();

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
                .AddAuthentication(options =>
                {
                    options.DefaultScheme = AuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = AuthenticationDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = AuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignOutScheme = AuthenticationDefaults.AuthenticationScheme;
                })
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

            serviceCollection
                .AddScoped<IUserClaimsPrincipalFactory<Account>, CustomUserClaimsPrincipalFactory>()
                .Configure<MvcOptions>(options =>
                {
                    AuthorizationPolicy policy =
                        new AuthorizationPolicyBuilder(AuthenticationDefaults.AuthenticationScheme)
                            .RequireAuthenticatedUser()
                            .Build();

                    options.Filters.Add(new AuthorizeFilter(policy));
                });

            serviceCollection
                .Configure<IdentityOptions>(options =>
                {
                    var name = configuration.GetSection("TokensOptions:ConfirmEmail:Name").Get<string>();
                    options.Tokens.ProviderMap.Add(
                        name,
                        new TokenProviderDescriptor(typeof(EmailConfirmationTokenProvider<Account>)));
                    options.Tokens.EmailConfirmationTokenProvider = name;
                });

            return serviceCollection;
        }
    }
}