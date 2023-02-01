using ModsDudeServer.Domain.Repo;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.RepoInvites.Exceptions;
public class AlreadyMemberException : Exception
{
    public AlreadyMemberException(UserId userId, RepoId repoId)
        : base($"{nameof(User)} with id '{userId}' is already a member of the {nameof(Repo)} with id '{repoId}'")
    {
    }
}
