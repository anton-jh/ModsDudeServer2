using ModsDudeServer.Domain.Information;
using ModsDudeServer.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Profiles;
public class Profile
{
    public Profile(RepoId repoId, DisplayName name)
    {
        Id = ProfileId.NewId();
        RepoId = repoId;
        Name = name;
        Mods = new HashSet<ModDependency>();
    }


    public ProfileId Id { get; }
    public RepoId RepoId { get; }
    public DisplayName Name { get; set; }
    public ISet<ModDependency> Mods { get; }
    public Savegame? Savegame { get; set; }
}
