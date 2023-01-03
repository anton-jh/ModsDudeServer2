using ModsDudeServer.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Entities;
public class Mod
{
    public Mod(ModId id, EntityName name, ICollection<Tag> tags, Description description, ICollection<ModVersion> versions)
    {
        Id = id;
        Name = name;
        Tags = tags;
        Description = description;
        Versions = versions;
    }


    public ModId Id { get; }
    public EntityName Name { get; }
    public ICollection<Tag> Tags { get; }
    public Description Description { get; set; }
    public ICollection<ModVersion> Versions { get; }
}
