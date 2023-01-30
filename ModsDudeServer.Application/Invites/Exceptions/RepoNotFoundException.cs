using ModsDudeServer.Domain.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.Invites.Exceptions;
public class RepoNotFoundException : Exception
{
    public RepoNotFoundException(RepoId repoId)
        : base($"{nameof(Repo)} with id '{repoId}' does not exist.")
    {
    }
}
