using ModsDudeServer.DataAccess;
using ModsDudeServer.Domain.Invites;
using ModsDudeServer.Domain.Users;
using ModsDudeServer.Modules.Invites.Shared.Exceptions;
using ModsDudeServer.Modules.Invites.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Modules.Invites.Shared.Implementations;
public class InviteClaimer : IInviteClaimer
{
    private readonly ApplicationDbContext _dbContext;


    public InviteClaimer(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public void ClaimInvite(InviteId inviteId, User user)
    {
        Invite? invite = GetInvite(inviteId);

        if (invite is null)
        {
            throw new InviteNotFoundException(inviteId);
        }

        if (invite.Expires <= DateTimeOffset.UtcNow)
        {
            throw new InviteExpiredException();
        }

        if (invite.MultiUse == false)
        {
            _dbContext.Invites.Remove(invite);
        }

        CreateMemberships(user, invite);

        _dbContext.SaveChanges();
    }


    private Invite? GetInvite(InviteId inviteId)
    {
        return _dbContext.Invites.Find(inviteId);
    }

    private void CreateMemberships(User user, Invite invite)
    {
        foreach (RepoInvite repoInvite in invite.RepoInvites)
        {
            if (user.IsMemberOf(repoInvite.RepoId))
            {
                continue;
            }

            if (_dbContext.Repos.Any(repo => repo.Id == repoInvite.RepoId) == false)
            {
                throw new RepoNotFoundException(repoInvite.RepoId);
            }

            user.RepoMemberships.Add(new()
            {
                RepoId = repoInvite.RepoId,
                Level = RepoMembershipLevel.Member
            });
        }
    }
}
