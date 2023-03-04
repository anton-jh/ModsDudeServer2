using ModsDudeServer.Application.Commands;
using ModsDudeServer.Application.Invites.Exceptions;
using ModsDudeServer.DataAccess;
using ModsDudeServer.Domain.Invites;
using ModsDudeServer.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.Invites;
public class CreateInviteHandler : ICommandHandler<CreateInviteCommand>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly InvitePruner _invitePruner;


    public CreateInviteHandler(ApplicationDbContext dbContext, InvitePruner invitePruner)
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
