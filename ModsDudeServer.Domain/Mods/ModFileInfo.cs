using ModsDudeServer.Domain.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.Domain.Mods;
public class ModFileInfo : ValueOf<(FileName FileName, FileSize FileSize), ModFileInfo>
{
    public FileName FileName => Value.FileName;
    public FileSize FileSize => Value.FileSize;
}
