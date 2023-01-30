using Microsoft.Extensions.DependencyInjection;
using ModsDudeServer.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.Authentication;
public static class AuthenticationModule
{
    public static IServiceCollection AddAuthenticationModule(this IServiceCollection services)
    {
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<ICommandHandler<SignupCommand>, SignupHandler>();
        services.AddScoped<IUserFactory, UserFactory>();

        return services;
    }
}
