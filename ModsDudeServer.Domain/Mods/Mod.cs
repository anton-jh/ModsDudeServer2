using ModsDudeServer.Domain.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModsDudeServer.Domain.Helpers;
using ModsDudeServer.Domain.Repos;

namespace ModsDudeServer.Domain.Mods;
public class Mod
{
    public Mod(ModId id, RepoId repoId, DisplayName name, Description description)
    {
        Id = id;
        RepoId = repoId;
        Name = name;
        Description = description;
        Categories = new HashSet<Category>();
        Versions = new ProtectedHashSet<ModVersion>();
    }


    public ModId Id { get; }
    public RepoId RepoId { get; }
    public DisplayName Name { get; }
    public Description Description { get; set; }
    public ISet<Category> Categories { get; init; }
    public ISet<ModVersion> Versions { get; init; }
}
