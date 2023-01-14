using ModsDudeServer.Domain.Games;
using ModsDudeServer.Domain.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Mods;
public class Mod
{
    public Mod(ModId id, GameId gameId, DisplayName name, Description description)
    {
        Id = id;
        GameId = gameId;
        Name = name;
        Description = description;
        Tags = new HashSet<Tag>();
        Versions = new HashSet<ModVersion>();
    }


    public ModId Id { get; }
    public GameId GameId { get; }
    public DisplayName Name { get; }
    public Description Description { get; set; }
    public ISet<Tag> Tags { get; init; }
    public ISet<ModVersion> Versions { get; init; }
}
