using ModsDudeServer.Domain.Invites;
using ModsDudeServer.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Modules.Invites.Shared.Exceptions;
public class InviteNotFoundException : Exception
{
    public InviteNotFoundException(InviteId inviteId)
        : base($"{nameof(Invite)} with id '{inviteId}' does not exist.")
    {
    }
}
