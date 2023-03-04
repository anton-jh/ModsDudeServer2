using ModsDudeServer.Domain.Invites;
using ModsDudeServer.Domain.Repos;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Modules.Authentication.Core.Register;
public record RegisterCommand
{
    public RegisterCommand(string username, string password, Guid inviteId)
    {
        Username = UserName.From(username);
        Password = Password.From(password);
        InviteId = InviteId.From(inviteId);
    }


    public UserName Username { get; }
    public Password Password { get; }
    public InviteId InviteId { get; }
}
