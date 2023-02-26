using ModsDudeServer.Application.Authentication;
using ModsDudeServer.Application.Commands;
using ModsDudeServer.Application.RepoInvites.Exceptions;
using ModsDudeServer.DataAccess;
using ModsDudeServer.Domain.Invites;
using ModsDudeServer.Domain.Repos;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.RepoInvites;
public class ClaimInviteHandler : ICommandHandler<ClaimRepoInviteCommand>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly RepoInvitePruner _pruner;


    public ClaimInviteHandler(ApplicationDbContext dbContext, RepoInvitePruner pruner)
    {
        _dbContext = dbContext;
        _pruner = pruner;
    }


    public void Handle(ClaimRepoInviteCommand command)
    {
        Invite? invite = GetInvite(command.InviteId);

        if (invite is null)
        {
            throw new InviteNotFoundException(command.InviteId);
        }

        if (invite.Expires <= DateTimeOffset.UtcNow)
        {
            throw new InviteExpiredException();
        }

        if (CheckAlreadyMember(command.User, invite.RepoId))
        {
            throw new AlreadyMemberException(command.User.Id, invite.RepoId);
        }

        if (invite.MultiUse == false)
        {
            _dbContext.Invites.Remove(invite);
        }

        RepoMembership membership = new()
        {
            RepoId = invite.RepoId,
            Level = invite.MembershipLevel
        };

        command.User.RepoMemberships.Add(membership);

        _dbContext.SaveChanges();

        _pruner.Prune();
    }


    private Invite? GetInvite(InviteId inviteId)
    {
        return _dbContext.Invites.Find(inviteId);
    }


    private static bool CheckAlreadyMember(User user, RepoId repoId)
    {
        return user.RepoMemberships.Any(membership => membership.RepoId == repoId);
    }
}
