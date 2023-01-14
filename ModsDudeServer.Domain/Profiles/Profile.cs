using ModsDudeServer.Domain.Games;
using ModsDudeServer.Domain.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Profiles;
public class Profile
{
    public Profile(GameId gameId, DisplayName name)
    {
        Id = ProfileId.NewId();
        GameId = gameId;
        Name = name;
        Mods = new HashSet<ModDependency>();
    }


    public ProfileId Id { get; }
    public GameId GameId { get; }
    public DisplayName Name { get; set; }
    public ISet<ModDependency> Mods { get; }
    public Savegame? Savegame { get; set; }
}
