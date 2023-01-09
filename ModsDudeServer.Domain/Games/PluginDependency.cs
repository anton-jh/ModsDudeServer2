using ModsDudeServer.Domain.Plugins;
using ModsDudeServer.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.Domain.Games;
public class PluginDependency : ValueOf<(PluginId PluginId, int Priority), PluginDependency>
{
    protected override void Validate()
    {
        Value.Priority.MustBe().GreaterThanOrEqualTo(0);
    }


    public PluginId PluginId => Value.PluginId;
    public int Priority => Value.Priority;
}
