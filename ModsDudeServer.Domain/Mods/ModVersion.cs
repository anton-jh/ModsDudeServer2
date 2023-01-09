using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Mods;
public class ModVersion
{
    public ModVersion(ModId modId, ModVersionString versionString, DateTime createdOn, ModFileInfo? file)
    {
        ModId = modId;
        VersionString = versionString;
        CreatedOn = createdOn;
        File = file;
    }


    public ModId ModId { get; }
    public ModVersionString VersionString { get; }
    public DateTime CreatedOn { get; }
    public ModFileInfo? File { get; }


    public static ModVersion NewModVersion(ModId modId, ModVersionString versionString, ModFileInfo? file)
        => new(modId, versionString, DateTime.Now, file);
}
