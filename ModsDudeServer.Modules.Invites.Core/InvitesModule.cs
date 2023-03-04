using Microsoft.Extensions.DependencyInjection;
using ModsDudeServer.Common.Messaging.Commands;
using ModsDudeServer.Modules.Invites.Core.Claim;
using ModsDudeServer.Modules.Invites.Core.Create;
using ModsDudeServer.Modules.Invites.Core.Pruning;
using ModsDudeServer.Modules.Invites.Shared.Implementations;
using ModsDudeServer.Modules.Invites.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Modules.Invites.Core;
public static class InvitesModule
{
    public static IServiceCollection AddInvitesModule(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<CreateInviteCommand>, CreateInviteHandler>();
        services.AddScoped<ICommandHandler<ClaimInviteCommand>, ClaimInviteHandler>();

        services.AddScoped<IInvitePruner, InvitePruner>();
        services.AddScoped<IInviteClaimer, InviteClaimer>();

        return services;
    }
}
