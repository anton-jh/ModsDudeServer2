using ModsDudeServer.Domain.Repos;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.Authentication;
public record SignupCommand
{
    public SignupCommand(string username, string password, Guid repoInviteId)
    {
        Username = UserName.From(username);
        Password = Password.From(password);
        RepoInviteId = RepoInviteId.From(repoInviteId);
    }


    public UserName Username { get; }
    public Password Password { get; }
    public RepoInviteId RepoInviteId { get; }
}
