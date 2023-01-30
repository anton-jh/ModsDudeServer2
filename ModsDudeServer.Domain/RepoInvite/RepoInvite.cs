using ModsDudeServer.Domain.Repo;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.Domain.Repos;
public class RepoInvite
{
    public RepoInvite(RepoId repoId, RepoMembershipLevel membershipLevel, DateTimeOffset expires, bool multiUse)
    {
        Id = RepoInviteId.NewId();
        RepoId = repoId;
        MembershipLevel = membershipLevel;
        Expires = expires;
        MultiUse = multiUse;
    }


    public RepoInviteId Id { get; init; }
    public RepoId RepoId { get; }
    public RepoMembershipLevel MembershipLevel { get; }
    public DateTimeOffset Expires { get; }
    public bool MultiUse { get; }
}
