using ModsDudeServer.Domain.Plugins;
using ModsDudeServer.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.Domain.Games;
public class PluginDependency
{
    public required PluginId PluginId { get; init; }
    public required int Priority { get; set; }
}
