using ModsDudeServer.Domain.Repos;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.Invites;
public class CreateInviteCommand
{
    public CreateInviteCommand(IEnumerable<Guid> repoIds, DateTimeOffset expires, bool multiUse)
    {
        RepoIds = repoIds.Select(RepoId.From);
        Expires = expires;
        MultiUse = multiUse;
    }


    public IEnumerable<RepoId> RepoIds { get; }
    public DateTimeOffset Expires { get; }
    public bool MultiUse { get; }
}
