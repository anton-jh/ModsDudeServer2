using ModsDudeServer.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.Invites;
public class ClaimRepoInviteCommand
{
    public ClaimRepoInviteCommand(Guid inviteId)
    {
        InviteId = RepoInviteId.From(inviteId);
    }


    public RepoInviteId InviteId { get; }
}
