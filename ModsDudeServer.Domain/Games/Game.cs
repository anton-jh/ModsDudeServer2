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
    public Game(GameId id, RepoId repoId, DisplayName name, IEnumerable<PluginDependency> plugins)
    {
        Id = id;
        RepoId = repoId;
        Name = name;
        Plugins = new HashSet<PluginDependency>(plugins);
    }


    public GameId Id { get; }
    public RepoId RepoId { get; }
    public DisplayName Name { get; set; }
    public ISet<PluginDependency> Plugins { get; }


    public static Game NewGame(RepoId repoId, DisplayName name, IEnumerable<PluginDependency> plugins)
        => new(GameId.NewId(), repoId, name, plugins);
}
