using ModsDudeServer.Domain.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Plugins;
public class Plugin
{
    public Plugin(PluginId id, DisplayName name, Description description)
    {
        Id = id;
        Name = name;
        Description = description;
    }


    public PluginId Id { get; }
    public DisplayName Name { get; set; }
    public Description Description { get; set; }
    public required PluginFileInfo File { get; set; }
}
