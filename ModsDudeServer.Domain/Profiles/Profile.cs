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
    public Profile(ProfileId id, GameId gameId, DisplayName name, IEnumerable<ModDependency> mods, Savegame? savegame)
    {
        Id = id;
        GameId = gameId;
        Name = name;
        Savegame = savegame;
        Mods = new HashSet<ModDependency>(mods);
    }


    public ProfileId Id { get; }
    public GameId GameId { get; }
    public DisplayName Name { get; set; }
    public ISet<ModDependency> Mods { get; }
    public Savegame? Savegame { get; set; }


    public static Profile NewProfile(GameId gameId, DisplayName name)
        => new(ProfileId.NewId(), gameId, name, Enumerable.Empty<ModDependency>(), null);
}
