using ModsDudeServer.Common.Messaging.Commands;
using ModsDudeServer.Domain.Invites;
using ModsDudeServer.Domain.Users;
using ModsDudeServer.Modules.Invites.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Modules.Invites.Core.Claim;
public class ClaimInviteHandler : ICommandHandler<ClaimInviteCommand>
{
    private readonly IInviteClaimer _inviteClaimer;


    public ClaimInviteHandler(IInviteClaimer inviteClaimer)
    {
        _inviteClaimer = inviteClaimer;
    }


    public void Handle(ClaimInviteCommand command)
    {
        _inviteClaimer.ClaimInvite(command.InviteId, command.User);
    }
}
