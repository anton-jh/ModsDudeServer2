using ModsDudeServer.Domain.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.Domain.Adapters;
public class AdapterFileInfo
{
    public required FileName FileName { get; init; }
    public required FileChecksum Checksum { get; init; }
}
