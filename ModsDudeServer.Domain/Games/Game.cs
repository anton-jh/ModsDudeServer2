using ModsDudeServer.Domain.Information;
using ModsDudeServer.Domain.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Games;
public class Game
{
    public Game(RepoId repoId, DisplayName name)
    {
        Id = GameId.NewId();
        RepoId = repoId;
        Name = name;
        Plugins = new HashSet<PluginDependency>();
    }


    public GameId Id { get; init; }
    public RepoId RepoId { get; }
    public DisplayName Name { get; set; }
    public ISet<PluginDependency> Plugins { get; init; }
}
