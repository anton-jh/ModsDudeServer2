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
    public Mod(ModId id, GameId gameId, DisplayName name, IEnumerable<Tag> tags, Description description, IEnumerable<ModVersion> versions)
    {
        Id = id;
        GameId = gameId;
        Name = name;
        Tags = new HashSet<Tag>(tags);
        Description = description;
        Versions = new HashSet<ModVersion>(versions);
    }


    public ModId Id { get; }
    public GameId GameId { get; }
    public DisplayName Name { get; }
    public ISet<Tag> Tags { get; }
    public Description Description { get; set; }
    public ISet<ModVersion> Versions { get; }


    public static Mod NewMod(ModId id, GameId gameId, DisplayName name, IEnumerable<Tag> tags, Description description, ModVersion version)
        => new(id, gameId, name, tags, description, new[] { version });
}
