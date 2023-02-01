using ModsDudeServer.Domain.Repos;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.RepoInvites;
public class ClaimRepoInviteCommand
{
    public ClaimRepoInviteCommand(Guid inviteId, User user)
    {
        InviteId = RepoInviteId.From(inviteId);
        User = user;
    }


    public RepoInviteId InviteId { get; }
    public User User { get; }
}
