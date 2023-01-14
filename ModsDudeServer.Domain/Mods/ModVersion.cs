using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Mods;
public class ModVersion
{
    public ModVersion(ModId modId, ModVersionString versionString)
    {
        ModId = modId;
        VersionString = versionString;
        CreatedOn = DateTime.Now;
    }


    public ModId ModId { get; }
    public ModVersionString VersionString { get; }
    public DateTime CreatedOn { get; init; }
    public ModFileInfo? File { get; set; }
}
