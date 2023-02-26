using ModsDudeServer.Domain.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Adapters;
public class Adapter
{
    public Adapter(AdapterId id, DisplayName name, Description description)
    {
        Id = id;
        Name = name;
        Description = description;
    }


    public AdapterId Id { get; }
    public DisplayName Name { get; set; }
    public Description Description { get; set; }
    public required AdapterFileInfo File { get; set; }
}
