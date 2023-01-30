using ModsDudeServer.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.Invites.Exceptions;
public class RepoInviteNotFoundException : Exception
{
    public RepoInviteNotFoundException(RepoInviteId inviteId)
        : base($"{nameof(RepoInvite)} with id '{inviteId}' does not exist.")
    {
    }
}
