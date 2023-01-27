using ModsDudeServer.Domain.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.Domain.Profiles;
public class ModDependency
{
    public required ModId ModId { get; init; }
    public required ModVersionString ModVersion { get; set; }
    public required bool IsProtected { get; set; }
}
