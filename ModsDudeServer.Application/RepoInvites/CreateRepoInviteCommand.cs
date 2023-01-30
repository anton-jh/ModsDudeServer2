using ModsDudeServer.Domain.Repo;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.RepoInvites;
public class CreateRepoInviteCommand
{
    public CreateRepoInviteCommand(Guid repoId, int membershipLevel, DateTimeOffset expires, bool multiUse)
    {
        RepoId = RepoId.From(repoId);
        MembershipLevel = RepoMembershipLevel.From(membershipLevel);
        Expires = expires;
        MultiUse = multiUse;
    }


    public RepoId RepoId { get; }
    public RepoMembershipLevel MembershipLevel { get; }
    public DateTimeOffset Expires { get; }
    public bool MultiUse { get; }
}
