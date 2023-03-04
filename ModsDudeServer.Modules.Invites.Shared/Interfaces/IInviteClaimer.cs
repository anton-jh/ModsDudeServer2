using ModsDudeServer.Domain.Invites;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Modules.Invites.Shared.Interfaces;
public interface IInviteClaimer
{
    void ClaimInvite(InviteId inviteId, User user);
}
