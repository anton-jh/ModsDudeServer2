using ModsDudeServer.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Entities;
public class ModVersion
{
    public ModVersion(ModId modId, ModVersionString versionString, ModFile file)
    {
        ModId = modId;
        VersionString = versionString;
        File = file;
    }


    public ModId ModId { get; }
    public ModVersionString VersionString { get; }
    public ModFile File { get; }
}
