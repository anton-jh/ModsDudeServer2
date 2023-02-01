using ModsDudeServer.Domain.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Users;
public class RepoMembership
{
    public required RepoId RepoId { get; init; }
    public required RepoMembershipLevel Level { get; set; }
}
