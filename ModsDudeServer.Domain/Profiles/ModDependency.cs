using ModsDudeServer.Domain.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.Domain.Profiles;
public class ModDependency : ValueOf<(ModId ModId, ModVersionString ModVersion, bool IsProtected), ModDependency>
{
    public ModId ModId => Value.ModId;
    public ModVersionString ModVersion => Value.ModVersion;
    public bool IsProtected => Value.IsProtected;
}
