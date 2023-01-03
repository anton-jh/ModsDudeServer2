using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.Domain.ValueObjects;
public class ModFile
{
    public ModFile(FileName fileName, FileSize fileSize)
    {
        FileName = fileName;
        FileSize = fileSize;
    }


    public FileName FileName { get; }
    public FileSize FileSize { get; }
}
