using ModsDudeServer.Domain.Invites;
using ModsDudeServer.Domain.Repos;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Modules.Invites.Core.Claim;
public class ClaimInviteCommand
{
    public ClaimInviteCommand(Guid inviteId, User user)
    {
        InviteId = InviteId.From(inviteId);
        User = user;
    }


    public InviteId InviteId { get; }
    public User User { get; }
}
