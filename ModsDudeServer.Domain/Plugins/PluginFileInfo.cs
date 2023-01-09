using ModsDudeServer.Domain.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.Domain.Plugins;
public class PluginFileInfo : ValueOf<(FileName FileName, FileChecksum Checksum), PluginFileInfo>
{
    public FileName FileName => Value.FileName;
    public FileChecksum Checksum => Value.Checksum;
}
