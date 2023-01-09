using ModsDudeServer.Domain.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Plugins;
public class Plugin
{
    public Plugin(PluginId id, DisplayName name, Description description, PluginFileInfo file)
    {
        Id = id;
        Name = name;
        Description = description;
        File = file;
    }


    public PluginId Id { get; }
    public DisplayName Name { get; set; }
    public Description Description { get; set; }
    public PluginFileInfo File { get; set; }


    public static Plugin NewPlugin(PluginId id, DisplayName name, Description description, PluginFileInfo file)
        => new(id, name, description, file);
}
