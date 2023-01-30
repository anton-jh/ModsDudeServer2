using ModsDudeServer.Application.Authentication;
using ModsDudeServer.Application.Commands;
using ModsDudeServer.Application.Invites.Exceptions;
using ModsDudeServer.DataAccess;
using ModsDudeServer.Domain.Repo;
using ModsDudeServer.Domain.Repos;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.Invites;
public class ClaimRepoInviteHandler : ICommandHandler<ClaimRepoInviteCommand>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IAuthenticatedUserProvider _authenticatedUserProvider;


    public ClaimRepoInviteHandler(ApplicationDbContext dbContext, IAuthenticatedUserProvider authenticatedUserProvider)
    {
        _dbContext = dbContext;
        _authenticatedUserProvider = authenticatedUserProvider;
    }


    public void Handle(ClaimRepoInviteCommand command)
    {
        RepoInvite? invite = GetInvite(command.InviteId);

        if (invite is null)
        {
            throw new RepoInviteNotFoundException(command.InviteId);
        }

        if (invite.Expires <= DateTimeOffset.UtcNow)
        {
            throw new InviteExpiredException();
        }

        User user = _authenticatedUserProvider.Get();

        if (CheckAlreadyMember(user, invite.RepoId))
        {
            throw new AlreadyMemberException(user.Id, invite.RepoId);
        }

        if (invite.MultiUse == false)
        {
            _dbContext.RepoInvites.Remove(invite);
        }

        RepoMembership membership = new()
        {
            RepoId = invite.RepoId,
            Level = invite.MembershipLevel
        };

        user.RepoMemberships.Add(membership);

        _dbContext.SaveChanges();
    }


    private RepoInvite? GetInvite(RepoInviteId inviteId)
    {
        return _dbContext.RepoInvites.Find(inviteId);
    }


    private static bool CheckAlreadyMember(User user, RepoId repoId)
    {
        return user.RepoMemberships.Any(membership => membership.RepoId == repoId);
    }
}
