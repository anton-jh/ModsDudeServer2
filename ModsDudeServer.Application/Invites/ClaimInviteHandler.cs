using ModsDudeServer.Application.Authentication;
using ModsDudeServer.Application.Commands;
using ModsDudeServer.Application.Invites.Exceptions;
using ModsDudeServer.DataAccess;
using ModsDudeServer.Domain.Invites;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.Invites;
public class ClaimInviteHandler : ICommandHandler<ClaimInviteCommand>
{
    private readonly ApplicationDbContext _dbContext;


    public ClaimInviteHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public void Handle(ClaimInviteCommand command)
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

        if (invite.MultiUse == false)
        {
            _dbContext.Invites.Remove(invite);
        }

        CreateMemberships(command.User, invite);

        _dbContext.SaveChanges();
    }


    private Invite? GetInvite(InviteId inviteId)
    {
        return _dbContext.Invites.Find(inviteId);
    }

    private static void CreateMemberships(User user, Invite invite)
    {
        foreach (RepoInvite repoInvite in invite.RepoInvites)
        {
            if (user.IsMemberOf(repoInvite.RepoId))
            {
                continue;
            }

            user.RepoMemberships.Add(new()
            {
                RepoId = repoInvite.RepoId,
                Level = RepoMembershipLevel.Member
            });
        }
    }
}
