using Microsoft.Extensions.DependencyInjection;
using ModsDudeServer.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.RepoInvites;
public static class RepoInvitesModule
{
    public static IServiceCollection AddRepoInvitesModule(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<CreateRepoInviteCommand>, CreateRepoInviteHandler>();
        services.AddScoped<ICommandHandler<ClaimRepoInviteCommand>, ClaimRepoInviteHandler>();
        services.AddScoped<RepoInvitePruner>();

        return services;
    }
}
