using ModsDudeServer.Common.Messaging.Commands;
using ModsDudeServer.DataAccess;
using ModsDudeServer.Domain.Invites;
using ModsDudeServer.Domain.Repos;
using ModsDudeServer.Modules.Invites.Core.Pruning;
using ModsDudeServer.Modules.Invites.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Modules.Invites.Core.Create;
public class CreateInviteHandler : ICommandHandler<CreateInviteCommand>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IInvitePruner _invitePruner;


    public CreateInviteHandler(ApplicationDbContext dbContext, IInvitePruner invitePruner)
    {
        _dbContext = dbContext;
        _invitePruner = invitePruner;
    }


    public void Handle(CreateInviteCommand command)
    {
        foreach (RepoId repoId in command.RepoIds)
        {
            if (CheckRepoExists(repoId) == false)
            {
                throw new RepoNotFoundException(repoId);
            }
        }

        Invite invite = new(command.Expires, command.MultiUse);

        _dbContext.Invites.Add(invite);
        _dbContext.SaveChanges();

        _invitePruner.Run();
    }


    private bool CheckRepoExists(RepoId repoId)
    {
        return _dbContext.Repos.Any(repo => repo.Id == repoId);
    }
}
