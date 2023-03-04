using ModsDudeServer.Domain.Repos;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Invites;
public class RepoInvite
{
    public required RepoId RepoId { get; init; }
}
