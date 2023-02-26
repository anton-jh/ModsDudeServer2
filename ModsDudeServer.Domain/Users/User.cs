using ModsDudeServer.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Users;
public class User
{
	public User(UserName userName, PasswordHash passwordHash)
	{
        Id = UserId.NewId();
        UserName = userName;
        PasswordHash = passwordHash;
        RepoMemberships = new HashSet<RepoMembership>();
    }


	public UserId Id { get; init; }
    public UserName UserName { get; set; }
    public PasswordHash PasswordHash { get; set; }
    public ISet<RepoMembership> RepoMemberships { get; init; }


    public bool IsMemberOf(RepoId repoId)
    {
        return RepoMemberships.Any(membership => membership.RepoId == repoId);
    }
}
