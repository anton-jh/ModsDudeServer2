using ModsDudeServer.Domain.Repos;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.Domain.Invites;
public class Invite
{
    public Invite(RepoMembershipLevel membershipLevel, DateTimeOffset expires, bool multiUse)
    {
        Id = InviteId.NewId();
        RepoInvites = new HashSet<RepoInvite>();
        MembershipLevel = membershipLevel;
        Expires = expires;
        MultiUse = multiUse;
    }


    public InviteId Id { get; init; }
    public ISet<RepoInvite> RepoInvites { get; init; }
    public RepoMembershipLevel MembershipLevel { get; }
    public DateTimeOffset Expires { get; }
    public bool MultiUse { get; }
}
