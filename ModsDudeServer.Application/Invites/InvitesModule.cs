using Microsoft.Extensions.DependencyInjection;
using ModsDudeServer.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.Invites;
public static class InvitesModule
{
    public static IServiceCollection AddRepoInvitesModule(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<CreateInviteCommand>, CreateInviteHandler>();
        services.AddScoped<ICommandHandler<ClaimInviteCommand>, ClaimInviteHandler>();
        services.AddScoped<InvitePruner>();

        return services;
    }
}
