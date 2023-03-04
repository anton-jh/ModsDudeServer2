using Microsoft.Extensions.DependencyInjection;
using ModsDudeServer.Common.Messaging.Commands;
using ModsDudeServer.Modules.Authentication.Core.Login;
using ModsDudeServer.Modules.Authentication.Core.Register;
using ModsDudeServer.Modules.Authentication.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Modules.Authentication.Core;
public static class AuthenticationModule
{
    public static IServiceCollection AddAuthenticationModule(this IServiceCollection services)
    {
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<ICommandHandler<RegisterCommand>, RegisterHandler>();

        services.AddScoped<IUserFactory, UserFactory>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
